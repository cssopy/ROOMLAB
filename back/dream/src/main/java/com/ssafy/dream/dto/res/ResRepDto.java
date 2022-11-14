package com.ssafy.dream.dto.res;


import com.ssafy.dream.entity.Reports;
import lombok.Getter;
import lombok.Setter;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;


@Getter
@Setter
public class ResRepDto {
    private Long repIdx;
    private Long expIdx;
    private String expTitle;
    private int repScore;
    private List<String> repAnswers;
    private Date repDate;
    private List<ResPicDto> pictures;

    public ResRepDto(Reports report, List<ResPicDto> pictures, ResExpDto experience) {
        this.repIdx = report.getRepIdx();
        this.expIdx = experience.getExpIdx();
        this.expTitle = experience.getExpTitle();
        this.repScore = report.getRepScore();
        this.repDate = report.getRepDate();
        this.repAnswers = new ArrayList<String>(
                List.of(report.getRepAnswer1(),
                        report.getRepAnswer2(),
                        report.getRepAnswer3(),
                        report.getRepAnswer4(),
                        report.getRepAnswer5()));
        this.pictures = pictures;
    }
}
