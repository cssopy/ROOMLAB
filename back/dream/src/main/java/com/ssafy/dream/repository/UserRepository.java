package com.ssafy.dream.repository;

import com.ssafy.dream.entity.Users;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<Long, Users> {
    Users findByUserId(String userId);
}
