using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ReportSettingScript : MonoBehaviour
{


    // 해당 위치에 있는 답 인덱스
    public int[] numbers = new int[5] { -1, -1, -1, -1, -1 };

    // 현재 타겟팅된 선택지
    public int target = -1;

    // 날짜와 시간
    private Text date;
    private Text username;

    // 현재 실험
    private int expIdx;

    System.Random random = new System.Random();

    // 1. 선택지 10개의 값
    private string[,] answers = new string[3, 10];
//    {
//        { "정전기 유도", "+", "-", "절연체", "털 뭉치", "실크", "대전", "집전체", "검전기 유도", "마찰력" }.OrderBy(x => random.Next()).ToArray(),
//        { "가장자리", "0.2", "산소", "3.2", "정중앙", "수소", "1.0", "기체 반응의", "0.8", "일정 성분비" },
//        { "염화 나트륨", "염화 칼슘", "흰색", "질산 구리", "검정색", "빨간색", "염화 마그네슘", "보라색", "1", "2"},
//    };
    // 0. 마찰 전기
    // 1. 구리 연소 반응
    // 2. 

    
    // 2. 활성화 시킬 빈칸들 -> 얘는 Awake에서 함수로 ㅇㅇ


    public void Awake()
    {
        // 실험 번호
        // expIdx = PlayerPrefs.GetInt("expIdx");
        expIdx = 0;

        // 날짜와 이름 세팅
        date = GameObject.Find("Date").GetComponent<Text>();
        username = GameObject.Find("Username").GetComponent<Text>();
        CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        date.text = DateTime.Now.ToString(string.Format($"yyyy년 MM월 dd일 ddd요일", cultures));
        // username.text = PlayerPrefs.GetString("userId");
        username.text = "홍성목";

        // 빈 칸들의 좌표 받아와서 사용
        for (int i = 0; i < 5; i++)
        {
            transform.Find($"Blank_{expIdx}_{i}").gameObject.SetActive(true);
        }

       
    }

    // 타겟팅 된 빈칸 저장

    public string SetAnswers(int n, int m)
    {
        return answers[n,m];
    }

    public void SelectAnswer(int t)
    {
        // 1. 똑같은 것을 연속으로 두 번 누른 상황인 경우 버튼 해제
        if (target == t)
        {
            transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.yellow;
            target = -1;
        }

        // 2. 전혀 다른 버튼인데 이전 값이 없으면 그냥 넣기
        else if (target == -1)
        {
            target = t;
        }

        // 3. 이전 값이 존재함
        else
        {
            transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.white;
            target = t;
        }

    }

    public string SelectBlank(int m)
    {
        // 1. 빈 자리에 값 넣기
        if (numbers[m] == -1)
        {
            // 숨기기 & 색 빼기
            GameObject obj = transform.Find($"Answer_{target}").gameObject;
            obj.SetActive(false);
            obj.GetComponent<Outline>().effectColor = Color.white;
            
            // 정답 채우기
            numbers[m] = target;

            // 초기화
            target = -1;

            // 값 넣기
            return answers[expIdx, numbers[m]];
        }

        // 2, 차 있는 값 빼기
        else
        {
            // 활성화
            transform.Find($"Answer_{numbers[m]}").gameObject.SetActive(true);
            
            // 정답 초기화
            numbers[m] = -1;

            // 값 넣기

            return "";

        }
    }
}
