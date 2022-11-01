package com.ssafy.dream.dto.req;


import lombok.Getter;

import java.util.List;

@Getter
public class ReqRepDto {
    private Long userIdx;
    private Long expIdx;
    private String repContent;
    private int repScore;
    private List<String> repAnswers;
}
