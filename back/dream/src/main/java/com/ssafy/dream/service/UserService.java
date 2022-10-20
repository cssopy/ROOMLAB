package com.ssafy.dream.service;

import com.ssafy.dream.config.jwt.JwtTokenProvider;
import com.ssafy.dream.dto.req.ReqUserDto;
import com.ssafy.dream.dto.res.ResLoginDto;
import com.ssafy.dream.dto.res.ResTokenDto;
import com.ssafy.dream.entity.Users;
import com.ssafy.dream.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Collections;
import java.util.List;

@Service
@RequiredArgsConstructor
public class UserService {
    private final UserRepository userRepository;

    private final PasswordEncoder passwordEncoder;

    private final JwtTokenProvider jwtTokenProvider;

    @Transactional
    public ResponseEntity<?> signUp(ReqUserDto reqUserDto){
        if(userRepository.existsByUserId(reqUserDto.getUserId())){
            return new ResponseEntity<>(false, HttpStatus.BAD_REQUEST);
        }
        Users user = Users.builder()
                .userId(reqUserDto.getUserId())
                .userPwd(passwordEncoder.encode(reqUserDto.getUserPwd()))
                .roles(Collections.singletonList("ROLE_USER"))
                .build();
        userRepository.save(user);
        return new ResponseEntity<>(true, HttpStatus.OK);
    }

    @Transactional
    public ResponseEntity<?> withdrawal(ReqUserDto reqUserDto){
        Users user = userRepository.findByUserId(reqUserDto.getUserId());
        if(user != null){
            if(passwordEncoder.matches(reqUserDto.getUserPwd(), user.getUserPwd())){
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
                .access(resTokenDto.getAccess())
                .refresh(resTokenDto.getRefresh())
                .build();

        user.updateRefreshToken(resTokenDto.getRefresh());

        return new ResponseEntity<>(resLoginDto, HttpStatus.OK);
    }
}
