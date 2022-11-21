package com.ssafy.dream.repository;

import com.ssafy.dream.entity.Experimentations;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ExperimentationRepository extends JpaRepository<Experimentations, Long> {

    List<Experimentations> findAll();
    Experimentations findByExpIdx(Long expIdx);
}
