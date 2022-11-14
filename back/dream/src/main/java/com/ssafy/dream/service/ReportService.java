package com.ssafy.dream.service;


import com.ssafy.dream.dto.req.ReqRepDto;
import com.ssafy.dream.dto.res.ResExpDto;
import com.ssafy.dream.dto.res.ResPicDto;
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
import java.util.*;
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
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.NOT_FOUND);
        } else if (exp == null) {
            return new ResponseEntity<>("실험을 다시 선택해주세요", HttpStatus.NOT_FOUND);
        } else {
            int score = 0;
            if (reqRepDto.getRepAnswers().get(0).equals(exp.getExpAnswer1())) { score += 20; }
            if (reqRepDto.getRepAnswers().get(1).equals(exp.getExpAnswer2())) { score += 20; }
            if (reqRepDto.getRepAnswers().get(2).equals(exp.getExpAnswer3())) { score += 20; }
            if (reqRepDto.getRepAnswers().get(3).equals(exp.getExpAnswer4())) { score += 20; }
            if (reqRepDto.getRepAnswers().get(4).equals(exp.getExpAnswer5())) { score += 20; }

            Reports report = Reports.builder()
                    .userIdx(user)
                    .expIdx(exp)
                    .repScore(score)
                    .repAnswer1(reqRepDto.getRepAnswers().get(0))
                    .repAnswer2(reqRepDto.getRepAnswers().get(1))
                    .repAnswer3(reqRepDto.getRepAnswers().get(2))
                    .repAnswer4(reqRepDto.getRepAnswers().get(3))
                    .repAnswer5(reqRepDto.getRepAnswers().get(4))
                    .repDate(new Date())
                    .build();
            reportRepository.save(report);
            Map<String, Long> data = new HashMap<>();
            data.put("repIdx", report.getRepIdx());
            return new ResponseEntity<>(data, HttpStatus.OK);
        }

    }

    @Transactional
    public ResponseEntity<?> savePicture(Long userIdx, Long repIdx, List<MultipartFile> images) {
        Users user = userRepository.findByUserIdx(userIdx);
        Reports report = reportRepository.findByRepIdx(repIdx);
        if(user == null) {
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.NOT_FOUND);
        } else if (report == null) {
            return new ResponseEntity<>("존재하지 않는 보고서입니다", HttpStatus.NOT_FOUND);
        } else {
            for (MultipartFile image : images) {
                String picName = userIdx.toString() + "_" + repIdx.toString() + "_" + image.getOriginalFilename();
                File picture = new File(localPath, picName);
                try {
                    image.transferTo(picture);
                } catch (IOException e) {
                    return new ResponseEntity<>("사진 저장에 실패하였습니다", HttpStatus.BAD_REQUEST);
                }

                picture.setWritable(true);
                picture.setReadable(true);

                Pictures pictureEntity = Pictures.builder()
                        .repIdx(report)
                        .picName(picName)
                        .picSize(image.getSize())
                        .picUrl(uri+picName)
                        .build();
                pictureRepository.save(pictureEntity);
            }

            return new ResponseEntity<>(true, HttpStatus.OK);
        }
    }


    public ResponseEntity<?> findReport(Long userIdx, Long repIdx) {
        Users user = userRepository.findByUserIdx(userIdx);
        Reports report = reportRepository.findByRepIdx(repIdx);
        if (user == null) {
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.NOT_FOUND);
        } else if (report == null) {
            return new ResponseEntity<>("존재하지 않는 보고서입니다", HttpStatus.NOT_FOUND);
        } else if (report.getUserIdx() != user) {
            return new ResponseEntity<>("잘못된 접근입니다", HttpStatus.NOT_FOUND);
        } else {
            List<Pictures> pictures = pictureRepository.findAllByRepIdx(report);
            ResRepDto resRepDto = new ResRepDto(report, pictures.stream().map(ResPicDto::new).collect(Collectors.toList()), new ResExpDto(report.getExpIdx()));
            Map<String, ResRepDto> userReports = new HashMap<>();
            userReports.put("report", resRepDto);
            return new ResponseEntity<>(resRepDto, HttpStatus.OK);
        }
    }


    public ResponseEntity<?> findUserReport(Long userIdx) {
        Users user = userRepository.findByUserIdx(userIdx);
        if (user == null) {
            return new ResponseEntity<>("존재하지 않는 유저입니다", HttpStatus.NOT_FOUND);
        } else {
            List<Reports> reports = reportRepository.findAllByUserIdx(user);
            List<ResRepDto> reportsList = new ArrayList<>();
            for (Reports report : reports) {
                List<Pictures> pictures = pictureRepository.findAllByRepIdx(report);
                reportsList.add(new ResRepDto(report, pictures.stream().map(ResPicDto::new).collect(Collectors.toList()), new ResExpDto(report.getExpIdx())));
            }
            Map<String, List> userReports = new HashMap<>();
            userReports.put("reports", reportsList);
            return new ResponseEntity<>(userReports, HttpStatus.OK);
        }
    }

}
