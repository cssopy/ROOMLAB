package com.ssafy.dream.repository;

import com.ssafy.dream.entity.Reports;
import com.ssafy.dream.entity.Users;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ReportRepository extends JpaRepository<Reports, Long> {

    List<Reports> findAllByUserIdx(Users userIdx);

    Reports findByRepIdx(Long repIdx);
}
