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
@Table(name = "experimentations")
public class Experimentations {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "exp_idx")
    private Long expIdx;

    @Column(name = "exp_title")
    private String expTitle;

    @Column(name = "exp_detail", columnDefinition = "text")
    private String expDetail;
}
