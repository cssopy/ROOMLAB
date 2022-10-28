package com.ssafy.dream.controller;

import com.ssafy.dream.dto.req.ReqSignupDto;
import com.ssafy.dream.dto.req.ReqTokenDto;
import com.ssafy.dream.dto.req.ReqUserDto;
import com.ssafy.dream.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/user")
@RequiredArgsConstructor
public class UserController {

    private final UserService userService;

    @PostMapping("/signup")
    public ResponseEntity<?> signUp(@RequestBody ReqSignupDto reqSignupDto) {
        return userService.signUp(reqSignupDto);
    }

    @GetMapping("/checkId/{userId}")
    public ResponseEntity<?> checkId(@PathVariable String userId){
        return userService.checkId(userId);
    }

    @PostMapping("/withdrawal")
    public ResponseEntity<?> withdrawal(@RequestBody ReqUserDto reqUserDto){
        return userService.withdrawal(reqUserDto);
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody ReqUserDto reqUserDto){
        return userService.login(reqUserDto);
    }

    @PostMapping("/logout")
    public ResponseEntity<?> logout(@RequestBody ReqUserDto reqUserDto){
        return userService.logout(reqUserDto);
    }

    @PostMapping("/check")
    public ResponseEntity<?> check(@RequestBody ReqTokenDto reqTokenDto){
        return userService.check(reqTokenDto);
    }
}
