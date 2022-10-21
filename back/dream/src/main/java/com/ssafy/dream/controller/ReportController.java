package com.ssafy.dream.controller;


import com.ssafy.dream.service.ReportService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/report")
@RequiredArgsConstructor
public class ReportController {

    private final ReportService reportService;

//    @PostMapping("save")
//    public ResponseEntity<?> saveReport(@ResponseBody ReqRepDto reqRepDto) {
//
//    }
}
