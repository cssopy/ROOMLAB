package com.ssafy.dream.dto.req;

import com.ssafy.dream.entity.enumtype.GenderType;
import lombok.Getter;

@Getter
public class ReqSignupDto {

    private String userId;

    private String userPwd;

    private GenderType userGender;
}
