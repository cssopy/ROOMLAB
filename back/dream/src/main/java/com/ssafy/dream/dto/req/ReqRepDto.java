package com.ssafy.dream.dto.req;


import lombok.Getter;

@Getter
public class ReqRepDto {
    private Long repIdx;
    private Long userIdx;
    private Long expIdx;
    private String repContent;
    private int repScore;
}
