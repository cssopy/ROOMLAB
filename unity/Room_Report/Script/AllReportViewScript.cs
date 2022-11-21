using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;



[System.Serializable]
public class AllReport
{
    public int userIdx;
    public int expIdx;
    public string expTitle;
    public int repScore;
    public string repDate;
    public List<string> repAnswers;
    public List<AllPicture> pictures;
}

[System.Serializable]
public class AllPicture
{
    public int picIdx;
    public string picName;
    public string picUrl;
}

[System.Serializable]
public class UserAllReport
{
    public List<AllReport> reports;
}

public class CheckAllReport
{
    public string userId;
    public string refresh;
}

public class AllReportViewScript : MonoBehaviour
{
    // 보고 있는 리포트의 인덱스
    private int targetIdx = 0;

    // 현재 유저 Idx
    private int userIdx;

    // 모든 보고서 목록
    private List<AllReport> reports;

    // 현재 보고서의 사진 목록
    private List<AllPicture> pictures;

    // 사진을 띄울 사진 오브젝트 목록
    public GameObject[] ReportPics = new GameObject[5];

    // 사진 크게 보여주는 창
    public GameObject PicPreview;

    // 날짜와 이름
    private Text date;
    private Text username;

    // 페이지네이션
    private int pageIdx = 0;

    // 보고서 리스트 파트
    public GameObject board;

    // 텍스쳐 불러 올 더미 목록들
    public List<Texture2D> textures = new List<Texture2D>();

    // 토큰
    private string token;


    private string[,] total_answers = new string[11, 5]
    {
        { "", "", "", "", ""},
        { "-", "정전기 유도", "절연체", "털 뭉치", "+" },
        { "팽창", "열 팽창률", "철", "구리", "수축" },
        { "염화 나트륨", "질산 구리", "보라색", "빨간색", "황록색"},
        { "용해도", "크로마토그래피", "성분 물질", "노랑", "보라"},
        { "염화 은", "아이오딘 화", "납", " 아이오딘화 납", "앙금"},
        { "북", "남", "N", "S", "동일한"},
        { "흰색", "없다", "보존", "탄산 칼슘", "질량 보존"},
        { "산소", "가장자리", "1.0", "0.2", "일정 성분비"},
        { "세포 주기", "세포 핵", "염색체", "간기", "개수"},
        { "긴", "넘치지 않도록", "염화 나트륨", "나프탈렌", "거름"},
    };

    public void OnEnable()
    {
        // 사용자 Idx
        userIdx = PlayerPrefs.GetInt("userIdx");
        // userIdx = 1;

        // 이름 세팅
        username = GameObject.Find("RepUsername").GetComponent<Text>();
        username.text = PlayerPrefs.GetString("userId");
        // username.text = "홍성목";

        FindAllReport();
    }

    // 전체 보고서 목록 불러오기
    public void FindAllReport()
    {
        token = PlayerPrefs.GetString("access");
        // token = "";
        string url = $"https://k7d101.p.ssafy.io/api/report/all/{userIdx}";
        // string url = $"http://localhost:8000/api/report/all/{userIdx}";
        StartCoroutine(FindAllRepCo(url));
    }

    public void LoadPicture(int n)
    {
        string picUrl = pictures[n].picUrl;
        StartCoroutine(LoadPicCo(picUrl, n));
    }

    IEnumerator CheckRefreshAllReport(string url)
    {
        CheckAllReport ck = new CheckAllReport
        {
            userId = PlayerPrefs.GetString("userId"),
            refresh = PlayerPrefs.GetString("refresh")
        };
        string checkJson = JsonConvert.SerializeObject(ck);
        using (UnityWebRequest request = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
        {
            byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
            request.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();


            // refresh 만료시
            if (request.responseCode == 403)
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadSceneAsync("children_room");
            }

            // 해당 유저의 토큰이 아닐 때
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // 성공 (Access 재발급)
            else if (request.responseCode == 200)
            {
                JObject obj = JObject.Parse(request.downloadHandler.text);
                token = "Bearer " + (string)obj["access"];
                PlayerPrefs.SetString("access", token);
                StartCoroutine(FindAllRepCo(url));
            }
        }
    }

    // 보고서 전체 찾아오는 함수
    IEnumerator FindAllRepCo(string url)
    {

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {

            request.SetRequestHeader("Authorization", "Bearer " + token);
            yield return request.SendWebRequest();

            // 오류
            if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // access 만료
            else if (request.responseCode == 403)
            {
                StartCoroutine(CheckRefreshAllReport(url));
            }

            // 해당 유저의 토큰이 아닐 때
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // 성공
            else if (request.responseCode == 200)
            {
                reports = JsonUtility.FromJson<UserAllReport>(request.downloadHandler.text).reports;
                
                // 리포트 리스트 세팅
                SettingReportList();

                // 기본 값으로 0번 리포트 세팅
                SettingReport(0);
            }
            request.Dispose();
        }
    }

    IEnumerator LoadPicCo(string url, int num)
    {
        using (UnityWebRequest imgReq = UnityWebRequestTexture.GetTexture(url))
        {
            yield return imgReq.SendWebRequest();
            if (imgReq.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(imgReq.error);
            }
            else
            {
                ReportPics[num].SetActive(true);
                ReportPics[num].GetComponent<RawImage>().texture = ((DownloadHandlerTexture)imgReq.downloadHandler).texture;
            }
            imgReq.Dispose();
        }
    }

    // 페이지에 따른 리포트 목록 세팅
    private void SettingReportList()
    {
        for (int k = 0; k < 14; k++)
        {
            board.transform.GetChild(k).gameObject.SetActive(false);
        }

        for (int i = 0; i < reports.Count - pageIdx * 12; i++)
        {
            if (i == 12)
            {
                break;
            }
            else
            {
                GameObject reportLine = board.transform.GetChild(i).gameObject;
                reportLine.GetComponent<RawImage>().texture = textures[reports[i + pageIdx * 12].expIdx - 1];
                string[] dates = reports[i + pageIdx * 12].repDate.Split(" ");
                reportLine.transform.GetChild(0).GetComponent<Text>().text = $"{dates[1][0]}{dates[1][1]}/{dates[2][0]}{dates[2][1]} ({dates[3][0]})";
                reportLine.SetActive(true);
            }
        }

        if (reports.Count > (pageIdx + 1) * 12) { board.transform.GetChild(13).gameObject.SetActive(true); }
        if (pageIdx != 0) { board.transform.GetChild(12).gameObject.SetActive(true); }
    }    


    // 입력 값으로 리포트 변경
    public void SettingReport(int r)
    {
        // 이전 실험 끄기
        transform.Find($"ReportViewImg_{reports[targetIdx].expIdx}").gameObject.SetActive(false);
        transform.Find($"Score_{reports[targetIdx].repScore}").gameObject.SetActive(false);

        targetIdx = r + pageIdx * 12;

        // 이번 실험 키기
        GameObject reportImg = transform.Find($"ReportViewImg_{reports[targetIdx].expIdx}").gameObject;
        reportImg.SetActive(true);
        transform.Find($"Score_{reports[targetIdx].repScore}").gameObject.SetActive(true);


        // 날짜 세팅
        date = GameObject.Find("RepDate").GetComponent<Text>();
        date.text = reports[targetIdx].repDate;


        // 빈칸 세팅
        for (int i = 0; i < 5; i++)
        {
            // 겸사겸사 사진도 끄기
            ReportPics[i].SetActive(false);

            GameObject blank = reportImg.transform.GetChild(i).gameObject;
            if (total_answers[reports[targetIdx].expIdx, i] != reports[targetIdx].repAnswers[i])
            {
                blank.GetComponent<Outline>().effectColor = Color.red;
                blank.transform.GetChild(0).GetComponent<Text>().color = Color.red;
                reportImg.transform.Find($"ViewAnswer_{i}").GetChild(0).GetComponent<Text>().text = total_answers[reports[targetIdx].expIdx, i];
            }
            blank.transform.GetChild(0).GetComponent<Text>().text = reports[targetIdx].repAnswers[i];
        }

        // 사진 호출
        pictures = reports[targetIdx].pictures;
        for (int j = 0; j < pictures.Count; j++)
        {
            LoadPicture(j);
        }
    }

    // 리포트 확인 키는 버튼 또는 닫는 버튼
    public void ToggleReportView()
    {
        transform.parent.gameObject.SetActive(!transform.parent.gameObject.activeSelf);
        board.transform.parent.gameObject.SetActive(!board.transform.parent.gameObject.activeSelf);
    }

    // 사진 미리보기 온 오프
    public void TogglePreview(int t)
    {
        if (t == -1)
        {
            PicPreview.SetActive(false);
            PicPreview.GetComponent<RawImage>().texture = null;
        }
        else
        {
            PicPreview.GetComponent<RawImage>().texture = ReportPics[t].GetComponent<RawImage>().texture;
            PicPreview.SetActive(true);
        }
    }

    // 페이지 이동
    public void Pagination(int p)
    {
        pageIdx += p;
        SettingReportList();
    }
}
