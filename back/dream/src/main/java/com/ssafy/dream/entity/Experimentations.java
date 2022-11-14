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

    @Column(name = "exp_grade")
    private int expGrade;

    @Column(name = "exp_subject")
    private String expSubject;

    @Column(name = "exp_answer_1")
    private String expAnswer1;

    @Column(name = "exp_answer_2")
    private String expAnswer2;

    @Column(name = "exp_answer_3")
    private String expAnswer3;

    @Column(name = "exp_answer_4")
    private String expAnswer4;

    @Column(name = "exp_answer_5")
    private String expAnswer5;

}
