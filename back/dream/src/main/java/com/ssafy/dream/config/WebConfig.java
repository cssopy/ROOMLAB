package com.ssafy.dream.config;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.resource.PathResourceResolver;


@Configuration
public class WebConfig implements WebMvcConfigurer {

    private final String uploadImagePath;

    public WebConfig(@Value("${spring.servlet.multipart.location}") String uploadImagePath) {
        this.uploadImagePath = uploadImagePath;
    }

    @Override
    public void addResourceHandlers(ResourceHandlerRegistry registry) {
        registry.addResourceHandler("swagger-ui.html")
                .addResourceLocations("classpath:/META-INF/resources/");


        registry.addResourceHandler("/static/img/**")
                .addResourceLocations("file:///" + uploadImagePath + "/")
                .setCachePeriod(3600)
                .resourceChain(true)
                .addResolver(new PathResourceResolver());
    }
}
