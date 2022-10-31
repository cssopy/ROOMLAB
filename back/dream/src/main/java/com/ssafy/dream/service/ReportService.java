package com.ssafy.dream.service;


import com.ssafy.dream.dto.req.ReqRepDto;
import com.ssafy.dream.dto.res.ResRepDto;
import com.ssafy.dream.entity.Experimentations;
import com.ssafy.dream.entity.Pictures;
import com.ssafy.dream.entity.Reports;
import com.ssafy.dream.entity.Users;
import com.ssafy.dream.repository.ExperimentationRepository;
import com.ssafy.dream.repository.PictureRepository;
import com.ssafy.dream.repository.ReportRepository;
import com.ssafy.dream.repository.UserRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class ReportService {
    private final ReportRepository reportRepository;
    private final UserRepository userRepository;
    private final ExperimentationRepository experimentationRepository;
    private final PictureRepository pictureRepository;

    @Value("${spring.servlet.multipart.location}")
    private String localPath;

    @Value("${spring.servlet.multipart.uri}")
    private String uri;


    @Transactional
    public ResponseEntity<?> saveReport(ReqRepDto reqRepDto) {
        Users user = userRepository.findByUserIdx(reqRepDto.getUserIdx());
        Experimentations exp = experimentationRepository.findByExpIdx(reqRepDto.getExpIdx());
        if(user == null) {
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.BAD_REQUEST);
        } else if (exp == null) {
            return new ResponseEntity<>("실험을 다시 선택해주세요", HttpStatus.BAD_REQUEST);
        } else if (reqRepDto.getRepContent().length() == 0) {
            return new ResponseEntity<>("보고서 내용을 작성해주세요", HttpStatus.BAD_REQUEST);
        } else {
            Reports report = Reports.builder()
                    .userIdx(user)
                    .expIdx(exp)
                    .repContent(reqRepDto.getRepContent())
                    .repScore(reqRepDto.getRepScore())
                    .build();
            reportRepository.save(report);
            Map<String, Long> data = new HashMap<>();
            data.put("repIdx", report.getRepIdx());
            return new ResponseEntity<>(data, HttpStatus.OK);
        }

    }

    @Transactional
    public ResponseEntity<?> updateReport(ReqRepDto reqRepDto) {
        Reports report = reportRepository.findByRepIdx(reqRepDto.getRepIdx());
        if (report == null) {
            return new ResponseEntity<>("존재하지 않는 보고서입니다", HttpStatus.BAD_REQUEST);
        } else {
            report.updateContent(reqRepDto.getRepContent());
            return new ResponseEntity<>(true, HttpStatus.OK);
        }
    }

    @Transactional
    public ResponseEntity<?> savePicture(Long userIdx, Long repIdx, MultipartFile image) {
        Users user = userRepository.findByUserIdx(userIdx);
        Reports report = reportRepository.findByRepIdx(repIdx);
        if(user == null) {
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.BAD_REQUEST);
        } else if (report == null) {
            return new ResponseEntity<>("존재하지 않는 보고서입니다", HttpStatus.BAD_REQUEST);
        } else {
            String picName = userIdx.toString() + "_" + repIdx.toString() + "_" + image.getOriginalFilename();
            File picture = new File(localPath, picName);
            try {
                image.transferTo(picture);
            } catch (IOException e) {
                System.out.println("저장 실패");
                return new ResponseEntity<>("사진 저장에 실패하였습니다", HttpStatus.BAD_REQUEST);
            }

            picture.setWritable(true);
            picture.setReadable(true);

            Pictures pictureEntity = Pictures.builder()
                    .picName(picName)
                    .picSize(image.getSize())
                    .picUrl(uri+picName)
                    .build();
            pictureRepository.save(pictureEntity);
            report.setPicture(pictureEntity);


            return new ResponseEntity<>(true, HttpStatus.OK);
        }
    }


    public ResponseEntity<?> findUserReport(Long userIdx) {
        Users user = userRepository.findByUserIdx(userIdx);
        if (user == null) {
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.BAD_REQUEST);
        } else {
            List<Reports> reports = reportRepository.findAllByUserIdx(user);
            List<ResRepDto> reportsList = reports.stream().map(ResRepDto::new).collect(Collectors.toList());
            return new ResponseEntity<>(reportsList, HttpStatus.OK);
        }
    }

}
