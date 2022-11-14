package com.ssafy.dream.entity;


import com.sun.istack.NotNull;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.Date;

@Entity
@Builder
@Getter
@NoArgsConstructor
@AllArgsConstructor
@Table(name = "reports")
public class Reports {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "rep_idx", columnDefinition = "int")
    private Long repIdx;

    @ManyToOne
    @JoinColumn(name = "exp_idx")
    private Experimentations expIdx;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "user_idx")
    private Users userIdx;

    @Column(name = "rep_score")
    @NotNull
    private int repScore;

    @Column(name = "rep_answer_1")
    @NotNull
    private String repAnswer1;

    @Column(name = "rep_answer_2")
    @NotNull
    private String repAnswer2;

    @Column(name = "rep_answer_3")
    @NotNull
    private String repAnswer3;

    @Column(name = "rep_answer_4")
    @NotNull
    private String repAnswer4;

    @Column(name = "rep_answer_5")
    @NotNull
    private String repAnswer5;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(name = "rep_date")
    @NotNull
    private Date repDate;
}
