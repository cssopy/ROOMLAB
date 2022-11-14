package com.ssafy.dream.dto.res;


import com.ssafy.dream.entity.Reports;
import lombok.Getter;
import lombok.Setter;

import java.util.ArrayList;
import java.util.List;


import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;


@Getter
@Setter
public class ResRepDto {
    private Long repIdx;
    private Long expIdx;
    private String expTitle;
    private int repScore;
    private List<String> repAnswers;
    private String repDate;
    private List<ResPicDto> pictures;
    private String getDateTime(Date date) {
        DateFormat dateFormat = new SimpleDateFormat("yyyy년 MM월 dd일 ddd요일");
        return dateFormat.format(date);
    }

    public ResRepDto(Reports report, List<ResPicDto> pictures, ResExpDto experience) {
        this.repIdx = report.getRepIdx();
        this.expIdx = experience.getExpIdx();
        this.expTitle = experience.getExpTitle();
        this.repScore = report.getRepScore();
        this.repDate = getDateTime(report.getRepDate());
        this.repAnswers = new ArrayList<String>(
                List.of(report.getRepAnswer1(),
                        report.getRepAnswer2(),
                        report.getRepAnswer3(),
                        report.getRepAnswer4(),
                        report.getRepAnswer5()));
        this.pictures = pictures;
    }
}
