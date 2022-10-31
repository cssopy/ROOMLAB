package com.ssafy.dream.dto.res;


import com.ssafy.dream.entity.Pictures;
import lombok.Getter;

@Getter
public class ResPicDto {

    private Long picIdx;
    private String picName;
    private String picUrl;
    private Long picSize;

    public ResPicDto(Pictures picture) {
        this.picIdx = picture.getPicIdx();
        this.picName = picture.getPicName();
        this.picUrl = picture.getPicUrl();
        this.picSize = picture.getPicSize();
    }
}
