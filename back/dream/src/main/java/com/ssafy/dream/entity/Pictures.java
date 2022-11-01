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
@Table(name = "pictures")
public class Pictures {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "pic_idx")
    private Long picIdx;

    @ManyToOne
    @JoinColumn(name = "rep_idx")
    private Reports repIdx;

    @Column(name = "pic_name")
    @NotNull
    private String picName;

    @Column(name = "pic_url", columnDefinition = "text")
    private String picUrl;

    @Column(name = "pic_size")
    @NotNull
    private Long picSize;
}
