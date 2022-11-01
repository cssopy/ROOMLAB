package com.ssafy.dream.dto.res;

import com.ssafy.dream.entity.enumtype.GenderType;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Builder
@Getter
@Setter
public class ResLoginDto {

    private Long userIdx;

    private String userId;

    private String access;

    private String refresh;

    private GenderType userGender;

    private boolean userTutorial;
}
