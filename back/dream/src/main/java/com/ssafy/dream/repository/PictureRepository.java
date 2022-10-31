package com.ssafy.dream.repository;

import com.ssafy.dream.entity.Pictures;
import com.ssafy.dream.entity.Reports;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface PictureRepository extends JpaRepository<Pictures, Long> {
    List<Pictures> findAllByRepIdx(Reports report);
}
