package com.ssafy.dream.service;

import com.ssafy.dream.dto.req.ReqUserDto;
import com.ssafy.dream.entity.Users;
import com.ssafy.dream.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Collections;

@Service
@RequiredArgsConstructor
public class UserService {
    private final UserRepository userRepository;

    private final PasswordEncoder passwordEncoder;

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
}
