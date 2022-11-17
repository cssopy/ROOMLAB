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


    @PostMapping("/picture/{userIdx}/{repIdx}")
    public ResponseEntity<?> savePicture(@PathVariable("userIdx") Long userIdx, @PathVariable("repIdx") Long repIdx, @RequestPart List<MultipartFile> images) {
        return reportService.savePicture(userIdx, repIdx, images);
    }

    @PostMapping("/picture/{userIdx}/{repIdx}/url")
    public ResponseEntity<?> savePictureUrl(@PathVariable("userIdx") Long userIdx, @PathVariable("repIdx") Long repIdx, @RequestBody List<Long> pictures) {
        return reportService.savePictureUrl(userIdx, repIdx, pictures);
    }
    @PostMapping("/picture/admin/create/{expIdx}")
    public void saveAdminPicture(@PathVariable Long expIdx, @RequestParam List<MultipartFile> images) {
        reportService.saveAdminPicture(expIdx, images);
    }


    @GetMapping("/one/{userIdx}/{repIdx}")
    public ResponseEntity<?> findReport(@PathVariable Long userIdx, @PathVariable Long repIdx){
        return reportService.findReport(userIdx, repIdx);
    }

    @GetMapping("/exp/pictures/{expIdx}")
    public ResponseEntity<?> findPictures(@PathVariable Long expIdx){
        return reportService.findPictures(expIdx);
    }

    @GetMapping("/all/{userIdx}")
    public ResponseEntity<?> findUserReport(@PathVariable Long userIdx) {
        return reportService.findUserReport(userIdx);
    }
}
