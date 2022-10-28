package com.ssafy.dream.dto.req;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class ReqTokenDto {

    private String userId;

    private String refresh;
}
