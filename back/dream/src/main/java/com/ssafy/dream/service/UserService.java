package com.ssafy.dream.service;

import com.ssafy.dream.config.jwt.JwtTokenProvider;
import com.ssafy.dream.dto.req.ReqSignupDto;
import com.ssafy.dream.dto.req.ReqTokenDto;
import com.ssafy.dream.dto.req.ReqTutorialDto;
import com.ssafy.dream.dto.req.ReqUserDto;
import com.ssafy.dream.dto.res.ResLoginDto;
import com.ssafy.dream.dto.res.ResTokenDto;
import com.ssafy.dream.entity.Users;
import com.ssafy.dream.repository.ReportRepository;
import com.ssafy.dream.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Pattern;

@Service
@RequiredArgsConstructor
public class UserService {
    private final UserRepository userRepository;

    private final PasswordEncoder passwordEncoder;

    private final ReportRepository reportRepository;
    private final JwtTokenProvider jwtTokenProvider;

    @Transactional
    public ResponseEntity<?> signUp(ReqSignupDto reqSignupDto){
        if(userRepository.existsByUserId(reqSignupDto.getUserId())){
            return new ResponseEntity<>(false, HttpStatus.BAD_REQUEST);
        }

        // 아이디 정규표현식
        if(!Pattern.matches("^[가-힣|a-z|A-Z|0-9]*$", reqSignupDto.getUserId())){
            return new ResponseEntity<>("적절한 아이디가 아닙니다", HttpStatus.BAD_REQUEST);
        }

        // 비밀번호 정규표현식
        if(!Pattern.matches("^(?=.*[a-zA-Z])(?=.*\\d).{6,20}$", reqSignupDto.getUserPwd())){
            return new ResponseEntity<>("적절한 비밀번호가 아닙니다", HttpStatus.BAD_REQUEST);
        }
        Users user = Users.builder()
                .userId(reqSignupDto.getUserId())
                .userPwd(passwordEncoder.encode(reqSignupDto.getUserPwd()))
                .userGender(reqSignupDto.getUserGender())
                .roles(Collections.singletonList("ROLE_USER"))
                .build();
        userRepository.save(user);
        return new ResponseEntity<>(true, HttpStatus.OK);
    }

    @Transactional
    public ResponseEntity<?> checkId(String userId){
        Users user = userRepository.findByUserId(userId);
        if(user == null){
            return new ResponseEntity<>("사용 가능한 아이디입니다.", HttpStatus.OK);
        }
        else return new ResponseEntity<>("중복된 아이디입니다.", HttpStatus.BAD_REQUEST);
    }

    @Transactional
    public ResponseEntity<?> checkTutorial(ReqTutorialDto reqTutorialDto){
        Users user = userRepository.findByUserId(reqTutorialDto.getUserId());
        if(user == null){
            return new ResponseEntity<>("해당 유저는 없는 유저입니다.", HttpStatus.BAD_REQUEST);
        }
        if(reqTutorialDto.isUserTutorial() != user.isUserTutorial()){
            user.setUserTutorial(reqTutorialDto.isUserTutorial());
            return new ResponseEntity<>("변경되었습니다.", HttpStatus.OK);
        }
        return new ResponseEntity<>("변경사항이 없습니다.", HttpStatus.OK);
    }

    @Transactional
    public ResponseEntity<?> withdrawal(ReqUserDto reqUserDto){
        Users user = userRepository.findByUserId(reqUserDto.getUserId());
        if(user != null){
            if(passwordEncoder.matches(reqUserDto.getUserPwd(), user.getUserPwd())){
                reportRepository.deleteAllByUserIdx(user);
                userRepository.delete(user);
                return new ResponseEntity<>(true, HttpStatus.OK);
            }
            else return new ResponseEntity<>("비밀번호가 틀렸습니다", HttpStatus.BAD_REQUEST);
        }
        else return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.BAD_REQUEST);
    }

    @Transactional
    public ResponseEntity<?> login(ReqUserDto reqUserDto){
        Users user = userRepository.findByUserId(reqUserDto.getUserId());
        if(user == null){
            return new ResponseEntity<>(false, HttpStatus.BAD_REQUEST);
        }

        if(!passwordEncoder.matches(reqUserDto.getUserPwd(), user.getUserPwd())){
            return new ResponseEntity<>("비밀번호가 틀렸습니다", HttpStatus.BAD_REQUEST);
        }

        List<String> list = user.getRoles();

        ResTokenDto resTokenDto = jwtTokenProvider.createToken(user.getUserId(), list);

        ResLoginDto resLoginDto = ResLoginDto.builder()
                .userId(resTokenDto.getUserId())
                .userIdx(user.getUserIdx())
                .userGender(user.getUserGender())
                .userTutorial(user.isUserTutorial())
                .access(resTokenDto.getAccess())
                .refresh(resTokenDto.getRefresh())
                .build();

        user.updateRefreshToken(resTokenDto.getRefresh());

        return new ResponseEntity<>(resLoginDto, HttpStatus.OK);
    }

    @Transactional
    public ResponseEntity<?> logout(ReqUserDto reqUserDto){
        Users user = userRepository.findByUserId(reqUserDto.getUserId());
        if(user == null){
            return new ResponseEntity<>("현재 로그인한 아이디가 아닙니다.", HttpStatus.BAD_REQUEST);
        }

        if(user.getRefreshToken() == null){
            return new ResponseEntity<>("이미 로그아웃 상태입니다.", HttpStatus.BAD_REQUEST);
        }

        user.setRefreshToken(null);
        return new ResponseEntity<>(true, HttpStatus.OK);
    }

    @Transactional
    public ResponseEntity<?> check(ReqTokenDto reqTokenDto){
        // 해당 유저의 ref 토큰이 아닐 경우, 만료 시 getUserId()에서 걸림
        if(!jwtTokenProvider.getUserId(reqTokenDto.getRefresh()).equals(reqTokenDto.getUserId())){
            return new ResponseEntity<>("해당 유저의 토큰이 아닙니다", HttpStatus.BAD_REQUEST);
        }
        String access = jwtTokenProvider.validateRefreshToken(reqTokenDto.getRefresh());
        Map<String, String> map = new HashMap<>();
        map.put("access", access);
        return new ResponseEntity<>(map, HttpStatus.OK);
    }
}
