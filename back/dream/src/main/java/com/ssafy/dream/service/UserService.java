package com.ssafy.dream.service;

import com.ssafy.dream.dto.req.ReqSignupDto;
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
    public ResponseEntity<?> signUp(ReqSignupDto reqSignupDto){
        if(userRepository.existsByUserId(reqSignupDto.getUserId())){
            return new ResponseEntity<>(false, HttpStatus.BAD_REQUEST);
        }
        Users user = Users.builder()
                .userId(reqSignupDto.getUserId())
                .userPwd(passwordEncoder.encode(reqSignupDto.getUserPwd()))
                .roles(Collections.singletonList("ROLE_USER"))
                .build();
        userRepository.save(user);
        return new ResponseEntity<>(true, HttpStatus.OK);
    }
}
