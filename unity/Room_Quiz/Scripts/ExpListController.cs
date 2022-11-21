using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpListController : MonoBehaviour
{
    // 학년으로 거름
    private int Grade;

    // 실험 번호
    private string[,] ExpList = new string[7, 2]

    {
        { "1", "2" }, //, "마찰 전기 관찰 실험" },
        { "2", "2" }, //, "열 팽창과 바이메탈" },
        { "3", "2" }, //, "불꽃 반응 실험" },
        { "4", "2" }, //, "종이 크로마토그래피 실험" },
        { "5", "2" }, //, "앙금 생성 반응 실험" },
        { "6", "2" }, //, "자석 주위의 자기장 관찰 실험" },
        // { "12", "2" }, //, "인체의 신비로운 소화"},
        // { "7", "3" }, //, "화학 반응에서의 질량 보존 법칙" },
        // { "8", "3" }, //, "구리의 연소 반응" },
        // { "9", "3" }, //, "체세포 분열 관찰 실험" },
        // { "10", "3" }, //, "거름 실험" },
        { "11", "3" }, //, "우주 여행" },
    };

    // 현재 실험의 실험번호들
    private List<int> ExpListViews;


    // 페이지네이션
    private int PageIdx = 0;

    // 다섯 개의 줄들
    public List<GameObject> ExpLines;

    // 각 줄에 들어갈 텍스쳐
    public List<Texture2D> Textures;

    // 각 줄의 컴포넌트에 쓸 디테일
    public List<Texture2D> DetailTexture;

    // 상세 페이지
    public GameObject DetailView;

    // 메인 페이지
    public GameObject MainPage;

    // 전후 페이지 버튼
    public GameObject LeftBtn;
    public GameObject RightBtn;

    // 페이지 컴포넌트
    public GameObject GradePage;

    // 페이지 텍스쳐
    public List<Texture2D> Pages;

    // 이동할 실험 확인
    private int TargetNumber;

    // 최종 확인 창
    public GameObject ConfirmPanel;


    // 학년 세팅
    public void SetGrade(int g)
    {
        Grade = g;
        GradePage.GetComponent<RawImage>().texture = Pages[g - 1];
        SetExpList();
    }

    // 학년에 따라 리스트를 저장
    public void SetExpList()
    {
        ExpListViews = new List<int> { };

        // 전체를 저장
        if (Grade == 4)
        {
            for (int i = 0; i < ExpList.Length / 2 ; i++)
            {
                ExpListViews.Add(Int32.Parse(ExpList[i, 0]));
            }
        }

        // 전체가 아니라면 해당하는 목록만 저장
        else
        { 
            string g = Grade.ToString();
            for (int i = 0; i < ExpList.Length / 2; i++)
            {
                if (ExpList[i, 1] == g)
                {
                    ExpListViews.Add(Int32.Parse(ExpList[i, 0]));
                }
            }
        }
        LoadExpViews();
    }

    // 실험 목록 보여주기
    public void LoadExpViews()
    {
        // 일단 끄기, 항목들과 전후 버튼
        for (int j = 0; j < 5; j++)
        {
            ExpLines[j].SetActive(false);
        }
        LeftBtn.SetActive(false);
        RightBtn.SetActive(false);
        

        // 다섯 개 뿌리기
        for (int j = 0; j < ExpListViews.Count - PageIdx * 5; j++)
        {
            if (j == 5)
            {
                break;
            }

            else
            {
                ExpLines[j].GetComponent<RawImage>().texture = Textures[ExpListViews[j + PageIdx * 5] - 1];
                ExpLines[j].SetActive(true);
            }
        }

        if (PageIdx != 0) { LeftBtn.SetActive(true); }
        if ((PageIdx + 1) * 5 < ExpListViews.Count) { RightBtn.SetActive(true); }
    }    


    // 메인 페이지 돌아가기
    public void BackToMainPage()
    {
        // 끄는 과정 : 목록 끄기 및 페이지 인덱스 초기화
        for (int i = 0; i < 5; i++)
        {
            GradePage.transform.Find($"ExpLine_{i}").gameObject.SetActive(false);
        }
        PageIdx = 0;

        MainPage.SetActive(true);
        GradePage.SetActive(false);    
    }

    // 페이지 변경
    public void ChangePages(int k)
    {
        PageIdx += k;
        LoadExpViews();
    }

    // 상세 이미지 온 오프
    public void ToggleDetail(int n)
    {
        if (n == -1)
        {
            // 끄기
            DetailView.GetComponent<RawImage>().texture = null;
            DetailView.SetActive(false);
        }
        else
        {
            // 켜기
            DetailView.SetActive(true);
            DetailView.GetComponent<RawImage>().texture = DetailTexture[ExpListViews[PageIdx * 5 + n] - 1];
        }
    }

    // 확인 창 열고 닫기
    public void ToggleConfirmModal(int t)
    {
        if (t == -1)
        {
            TargetNumber = 0;
        }
        else
        {
            TargetNumber = ExpListViews[PageIdx * 5 + t];
        }
        ConfirmPanel.SetActive(!ConfirmPanel.activeSelf);
    }

    // 실험으로 이동
    public void MoveToLab()
    {
        PlayerPrefs.SetInt("expIdx", TargetNumber);
        // 1. 마찰 전기 관찰 실험
        if (TargetNumber == 1) { SceneManager.LoadScene("ElectrostaticInductionScene"); }

        // 2. 열 팽창과 바이메탈
        else if (TargetNumber == 2) { SceneManager.LoadScene("ThermalExpansionScene"); }

        // 3. 불꽃 반응 실험
        else if (TargetNumber == 3) { SceneManager.LoadScene("FlameTestScene"); }

        // 4. 종이 크로마토그래피 실험
        else if (TargetNumber == 4) { SceneManager.LoadScene("Laboratory_Room_Paper"); }

        // 5. 앙금 생성 반응 실험
        else if (TargetNumber == 5) { SceneManager.LoadScene("씬이름"); }

        // 6. 자석 주위의 자기장 관찰 실험
        else if (TargetNumber == 6) { SceneManager.LoadScene("Laboratory_Room_Magnetic"); }

        // 7. 화학 반응에서의 질량 보존 법칙
        else if (TargetNumber == 7) { SceneManager.LoadScene("씬이름"); }

        // 8. 구리의 연소 반응
        else if (TargetNumber == 8) { SceneManager.LoadScene("씬이름"); }

        // 9. 체세포 분열 관찰 실험
        else if (TargetNumber == 9) { SceneManager.LoadScene("씬이름"); }

        // 10. 거름 실험
        else if (TargetNumber == 10) { SceneManager.LoadScene("Laboratory_Room_Filter"); }

        // 11. 우주 여행 
        else if (TargetNumber == 11) { SceneManager.LoadScene("씬이름"); }

        // 12. 인체의 신비로운 소화
        else if (TargetNumber == 12) { SceneManager.LoadScene("씬이름"); }
    }
}
