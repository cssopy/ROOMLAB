package com.ssafy.dream.dto.res;

import lombok.Builder;
import lombok.Getter;
import lombok.Setter;

@Builder
@Getter
@Setter
public class ResLoginDto {

    private String userId;

    private String access;

    private String refresh;
}
