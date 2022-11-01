package com.ssafy.dream.dto.res;

import com.ssafy.dream.entity.Experimentations;
import lombok.Getter;

import java.util.ArrayList;
import java.util.List;

@Getter
public class ResExpDto {

    private Long expIdx;
    private String expTitle;
    private String expDetail;
//    private int expGrade;
//    private String expSubject;
//    private List<String> expAnswers;

    public ResExpDto(Experimentations experimentations) {
        this.expIdx = experimentations.getExpIdx();
        this.expTitle = experimentations.getExpTitle();
        this.expDetail = experimentations.getExpDetail();
//        this.expGrade = experimentations.getExpGrade();
//        this.expSubject = experimentations.getExpSubject();
//        this.expAnswers = new ArrayList<String>(
//                List.of(experimentations.getExpAnswer1(),
//                        experimentations.getExpAnswer2(),
//                        experimentations.getExpAnswer3(),
//                        experimentations.getExpAnswer4(),
//                        experimentations.getExpAnswer5()));
    }
}
