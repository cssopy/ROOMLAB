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
@Table(name = "pictures")
public class Pictures {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "pic_idx")
    private Long picIdx;

    @Column(name = "pic_name")
    private String picName;

    @Column(name = "pic_url")
    private String picUrl;

    @Column(name = "pic_size")
    private Long picSize;

    public void setPicUrl(String url) {this.picUrl = url;}
}
