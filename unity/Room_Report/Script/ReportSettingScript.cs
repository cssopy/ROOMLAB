using System;
using System.Linq;
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

    // 날짜와 이름
    private Text date;
    private Text username;

    // 현재 유서
    public int userIdx;

    // 현재 실험
    public int expIdx;

    // 외부 클릭 시 해제
    public GameObject shield;

    // 선택지 10개의 값
    // 1. 마찰 전기
    // 2. 열 팽창과 바이메탈
    // 3. 불꽃 반응
    // 4. 종이 크로마토 그래피
    // 5. 앙금 생성 반응
    // 6. 자기장 관찰
    // 7. 화학 반응에서의 질량 보존 법칙
    // 8. 구리의 연소 반응
    // 9. 체세포 분열 관찰
    // 10. 거름 실험
    // 11. 용수철 실험 (미완)

    private string[,] total_answers = new string[11, 10]
    {
        { "", "", "", "", "", "", "", "", "", "" },
        { "-", "정전기 유도", "절연체", "털 뭉치", "+", "실크", "집전체", "검전기 유도", "마찰력", "대전" },
        { "팽창", "열 팽창률", "철", "구리", "수축", "바이메탈", "증발", "열 전도율", "전하량", "열화" },
        { "염화 나트륨", "질산 구리", "보라색", "빨간색", "황록색", "파란색", "검정색", "흰색", "염화 칼슘", "염화 마그네슘"},
        { "용해도", "크로마토그래피", "성분 물질", "노랑", "보라", "용매도", "원심분리법", "온도", "원소", "분자"},
        { "염화 은", "아이오딘 화", "납", "아이오딘화 납", "앙금","질산 나트륨", "청록색", "염화", "구리", "염화 구리"},
        { "북", "남", "N", "S", "동일한", "동", "서", "E", "W", "반대되는"},
        { "흰색", "없다", "보존", "탄산 칼슘", "질량 보존", "노란색", "있다", "감소", "탄산 칼륨", "일정 성분비"},
        { "산소", "가장자리", "1.0", "0.2", "일정 성분비", "수소", "정중앙", "0.8", "3.2", "기체 반응"},
        { "세포 주기", "세포 핵", "염색체", "간기", "개수", "생장기", "중기", "후기", "딸세포", "부피"},
        { "긴", "넘치지 않도록", "염화 나트륨", "나프탈렌", "거름", "짧은", "넘치도록", "염소", "나트륨", "크로마토그래피" },
    };

    // 지금 실험의 선택지
    private string[] answers = new string[10];

    // 선택된 정답의 개수
    public int counts = 0;


    // 선택지 박스 오브젝트
    public GameObject selection;


    // 사진 저장용
    public GameObject pictures;
    public PictureScript pictureScript;

    // 리포트 저장 컨트롤러
    public GameObject other;
    public ReportController reportController;


    public void Awake()
    {
        // 실험 번호
        expIdx = PlayerPrefs.GetInt("expIdx");
        // expIdx = 3;

        // 현재 유저
        userIdx = PlayerPrefs.GetInt("userIdx");
        // userIdx = 1;

        // 날짜와 이름 세팅
        date = GameObject.Find("Date").GetComponent<Text>();
        username = GameObject.Find("Username").GetComponent<Text>();
        CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        date.text = DateTime.Now.ToString(string.Format($"yyyy년 MM월 dd일 ddd요일", cultures));
        username.text = PlayerPrefs.GetString("userId");
        // username.text = "홍성목";

        // 보고서 사진 활성화
        transform.Find($"ReportImg_{expIdx}").gameObject.SetActive(true);

        // 실험 답 랜덤화
        for (int i = 0; i < 10; i++)
        {
            answers[i] = total_answers[expIdx, i];
        }
        System.Random random = new System.Random();
        answers = answers.OrderBy(x => random.Next()).ToArray();

        // 답을 뿌리기
        for (int j = 0; j < 10; j++)
        {
            selection.transform.GetChild(j).transform.GetComponentInChildren<Text>().text = answers[j];
        }
    }


    public void SelectAnswer(int t)
    {
        // 1. 똑같은 것을 연속으로 두 번 누른 상황인 경우 버튼 해제
        if (target == t)
        {
            selection.transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.yellow;
            target = -1;
            shield.SetActive(false);
        }

        // 2. 전혀 다른 버튼인데 이전 값이 없으면 그냥 넣기
        else if (target == -1)
        {
            shield.SetActive(true);
            target = t;
        }

        // 3. 외부 클릭에 의한 취소
        else if (t == -1)
        {
            shield.SetActive(false);
            selection.transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.white;
            target = -1;

        }

        // 4. 이전 값이 존재함
        else
        {
            selection.transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.white;
            target = t;
        }

    }

    public string SelectBlank(int m)
    {
        // 1. 빈 자리에 값 넣기
        if (numbers[m] == -1)
        {
            // 숨기기 & 색 빼기
            GameObject obj = selection.transform.Find($"Answer_{target}").gameObject;
            obj.SetActive(false);
            obj.GetComponent<Outline>().effectColor = Color.white;
            
            // 정답 채우기
            numbers[m] = target;

            // 초기화
            target = -1;

            // 카운트 증가
            counts++;

            // 프로텍트 끄기
            shield.SetActive(false);

            // 값 넣기
            return answers[numbers[m]];
        }

        // 2, 차 있는 값 빼기
        else
        {
            // 활성화
            selection.transform.Find($"Answer_{numbers[m]}").gameObject.SetActive(true);
            
            // 정답 초기화
            numbers[m] = -1;

            // 카운트 감소
            counts--;

            // 값 넣기
            return "";

        }
    }

    // 보고서 열고 닫기
    public void ToggleReport()
    {
        // 아래는 구조에 따라 생략
        other.SetActive(true);

        transform.parent.gameObject.SetActive(false);
    }

    // 리포트 저장
    public void SaveUserReport()
    {
        reportController = other.GetComponent<ReportController>();
        List<string> repAnswers = new List<string> { };
        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] == -1)
            {
                repAnswers.Add("");
            }
            else
            {
                repAnswers.Add(answers[numbers[i]]);
            }
        }
        Report report = new Report()
        {
            userIdx = userIdx,
            expIdx = expIdx,
            repAnswers = repAnswers,
        };

        pictureScript = pictures.GetComponent<PictureScript>();
        reportController.SaveReport(report, pictureScript.selected);
    }
}
