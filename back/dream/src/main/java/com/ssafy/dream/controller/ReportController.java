package com.ssafy.dream.controller;


import com.ssafy.dream.dto.req.ReqRepDto;
import com.ssafy.dream.service.ReportService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.util.List;

@RestController
@RequestMapping("/api/report")
@RequiredArgsConstructor
public class ReportController {

    private final ReportService reportService;

    @PostMapping("/save")
    public ResponseEntity<?> saveReport(@RequestBody ReqRepDto reqRepDto) {
        return reportService.saveReport(reqRepDto);
    }


    @PutMapping("/update")
    public ResponseEntity<?> updateReport(@RequestBody ReqRepDto reqRepDto) {
        return reportService.updateReport(reqRepDto);
    }

    @PostMapping("/picture/{userIdx}/{repIdx}")
    public ResponseEntity<?> savePicture(@PathVariable("userIdx") Long userIdx, @PathVariable("repIdx") Long repIdx, @RequestParam MultipartFile image) {
        return reportService.savePicture(userIdx, repIdx, image);
    }


    @GetMapping("/all/{userIdx}")
    public ResponseEntity<?> findUserReport(@PathVariable Long userIdx) {
        return reportService.findUserReport(userIdx);
    }
}
