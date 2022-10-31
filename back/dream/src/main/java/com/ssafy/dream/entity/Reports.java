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
@Table(name = "reports")
public class Reports {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "rep_idx", columnDefinition = "int")
    private Long repIdx;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "exp_idx")
    private Experimentations expIdx;

    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "user_idx")
    private Users userIdx;

    @OneToOne
    @JoinColumn(name = "picture_idx")
    private Pictures pictureIdx;

    @Column(name = "rep_content", columnDefinition = "text")
    private String repContent;

    @Column(name = "rep_score")
    private int repScore;


    public void updateContent(String newRepContent) {
        this.repContent = newRepContent;
    }

    public void setPicture(Pictures picture) {this.pictureIdx = picture;}

}
