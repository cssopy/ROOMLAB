package com.ssafy.dream.dto.res;


import com.ssafy.dream.entity.Reports;
import lombok.Getter;
import lombok.Setter;


@Getter
@Setter
public class ResRepDto {
    private Long repIdx;
    private Long expIdx;
    private String expTitle;
    private String repContent;
    private int repScore;
    private ResPicDto repPicture;

    public ResRepDto(Reports report) {
        this.repIdx = report.getRepIdx();
        this.expIdx = report.getExpIdx().getExpIdx();
        this.expTitle = report.getExpIdx().getExpTitle();
        this.repContent = report.getRepContent();
        this.repScore = report.getRepScore();
        this.repPicture = report.getPictureIdx() != null ? new ResPicDto(report.getPictureIdx()) : null;
    }
}
