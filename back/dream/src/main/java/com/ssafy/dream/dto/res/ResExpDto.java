package com.ssafy.dream.dto.res;

import com.ssafy.dream.entity.Experimentations;
import lombok.Getter;

import java.util.ArrayList;
import java.util.List;

@Getter
public class ResExpDto {

    private Long expIdx;
    private String expTitle;
    private int expGrade;
    private String expSubject;

    public ResExpDto(Experimentations experimentations) {
        this.expIdx = experimentations.getExpIdx();
        this.expTitle = experimentations.getExpTitle();
        this.expGrade = experimentations.getExpGrade();
        this.expSubject = experimentations.getExpSubject();
    }
}
