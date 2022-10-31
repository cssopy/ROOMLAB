package com.ssafy.dream.dto.res;


import com.ssafy.dream.entity.Reports;
import lombok.Getter;
import lombok.Setter;

import java.util.List;


@Getter
@Setter
public class ResRepDto {
    private Long repIdx;
    private Long expIdx;
    private String expTitle;
    private String repContent;
    private int repScore;
    private List<ResPicDto> pictures;

    public ResRepDto(Reports report, List<ResPicDto> pictures) {
        this.repIdx = report.getRepIdx();
        this.expIdx = report.getExpIdx().getExpIdx();
        this.expTitle = report.getExpIdx().getExpTitle();
        this.repContent = report.getRepContent();
        this.repScore = report.getRepScore();
        this.pictures = pictures;
    }
}
