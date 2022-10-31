package com.ssafy.dream.entity;


import com.sun.istack.NotNull;
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
    @NotNull
    private Long expIdx;

    @Column(name = "exp_title")
    @NotNull
    private String expTitle;

    @Column(name = "exp_detail", columnDefinition = "text")
    @NotNull
    private String expDetail;

    @Column(name = "exp_grade")
    @NotNull
    private int expGrade;

    @Column(name = "exp_subject")
    @NotNull
    private String expSubject;
}
