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

    @Column(name = "rep_content", columnDefinition = "text")
    private String repContent;

    @Column(name = "rep_picture", columnDefinition = "text")
    private String repPicture;

    public void updateContent(String newRepContent) {
        this.repContent = newRepContent;
    }

    public void updatePicture(String newRepPicture) {
        this.repPicture = newRepPicture;
    }
}
