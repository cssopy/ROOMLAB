using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ReportSettingScript : MonoBehaviour
{
    // 10개 박스의 값들
    private string[] answers = new string[10];
    // 해당 위치에 있는 답 인덱스
    private int[] numbers = new int[5] { -1, -1, -1, -1, -1 };
    // 10개의 박스의 최초 위치
    public Vector3[] positions = new Vector3[10];
    // 5개의 빈칸의 최초 위치
    private Vector3[] blanks = new Vector3[5];
    // 현재 타겟팅된 박스
    public int target = -1;
    // 날짜와 시간
    private Text date;
    private Text username;
    
    // 기타 변수
    private GameObject obj;
    private GameObject obj2;


    public void Awake()
    {
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
            obj = GameObject.Find($"Blank_{i}");
            blanks[i] = obj.transform.position;
        }
    }

    // 타겟팅 된 빈칸 저장
    public void SetBlank(int t)
    {
        target = t;
    }

    public void SetAnswers(int n, Vector3 position, string text)
    {
        answers[n] = text;
        positions[n] = position;
    }

    public void SelectAnswer(int n)
    {
        if (target != -1)
        {
            // 타겟으로 위치를 바꿔야 함
            // 1. 기존에 있던 값이 있으면, 그 값을 원래 위치로 옮기기
            if (numbers[target] != -1)
            {
                int m = numbers[target];
                obj2 = transform.Find($"Answer_{m}").gameObject;
                obj2.transform.position = positions[m];
            }

            // 2. 빈 자리에 값을 넣기
            numbers[target] = n;
            obj = transform.Find($"Answer_{n}").gameObject;
            obj.transform.position = blanks[target];
            obj2 = transform.Find($"Blank_{target}").gameObject;
            obj2.GetComponent<Outline>().effectColor = Color.black;
            obj2.GetComponentInChildren<Text>().text = answers[n];
            target = -1;
            
        }
    }


}
