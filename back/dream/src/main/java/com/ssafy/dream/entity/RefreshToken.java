package com.ssafy.dream.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Builder
@Getter
@NoArgsConstructor
@AllArgsConstructor
@Table(name = "refresh")
public class RefreshToken {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ref_idx")
    private Long refIdx;

    @Column(name = "ref_token")
    private String refToken;

    public RefreshToken(String refToken) {
        this.refToken = refToken;
    }
}
