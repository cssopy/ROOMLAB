package com.ssafy.dream.repository;

import com.ssafy.dream.entity.Users;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends JpaRepository<Users, Long> {
    Users findByUserId(String userId);

    boolean existsByUserId(String userId);
}
