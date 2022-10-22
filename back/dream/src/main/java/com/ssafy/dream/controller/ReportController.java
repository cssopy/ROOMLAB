package com.ssafy.dream.controller;


import com.ssafy.dream.dto.req.ReqRepDto;
import com.ssafy.dream.service.ReportService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

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

    @GetMapping("/{userIdx}")
    public ResponseEntity<?> findUserReport(@PathVariable Long userIdx) {
        return reportService.findUserReport(userIdx);
    }
}
