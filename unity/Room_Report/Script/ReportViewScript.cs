using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Reports
{
    public int userIdx;
    public int expIdx;
    public string expTitle;
    public int repScore;
    public string repDate;
    public List<string> repAnswers;
    public List<Picture> pictures;
}

[System.Serializable]
public class Picture
{
    public int picIdx;
    public string picName;
    public string picUrl;
}

public class CheckView
{
    public string userId;
    public string refresh;
}

public class ReportViewScript : MonoBehaviour
{
    private int repIdx;
    private int userIdx;
    private Reports report;
    private List<Picture> pictures;
    public GameObject[] ReportPics = new GameObject[5];
    public GameObject PicPreview;

    // 날짜와 이름
    private Text date;
    private Text username;

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
        repIdx = PlayerPrefs.GetInt("repIdx");
        userIdx = PlayerPrefs.GetInt("userIdx");
        // repIdx = 2;
        // userIdx = 1;


        // 이름 세팅
        username = GameObject.Find("RepUsername").GetComponent<Text>();
        username.text = PlayerPrefs.GetString("userId");
        // username.text = "홍성목";


        // 토큰 설정
        token = PlayerPrefs.GetString("access");
        // token = "";

        FindReport();
    }

    public void FindReport()
    {
        string url = $"https://k7d101.p.ssafy.io/api/report/one/{userIdx}/{repIdx}";
        // string url = $"http://localhost:8000/api/report/one/{userIdx}/{repIdx}";
        StartCoroutine(FindRepCo(url));
    }

    public void LoadPicture(int n)
    {
        string picUrl = pictures[n].picUrl;
        StartCoroutine(LoadPicCo(picUrl, n));
    }

    IEnumerator CheckRefreshView(string url)
    {
        CheckView ck = new CheckView
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
                FindRepCo(url);
            }
        }
    }

    IEnumerator FindRepCo(string url)
    {

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", token);
            yield return request.SendWebRequest();

            // 오류 발생
            if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // access 만료
            else if (request.responseCode == 403)
            {
                CheckRefreshView(url);
            }

            // 해당 유저의 토큰이 아닐 때
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // 통과 시
            else if (request.responseCode == 200)
            {
                report = JsonUtility.FromJson<Reports>(request.downloadHandler.text);
                pictures = report.pictures;
                SettingReport();
                for (int i = 0; i < pictures.Count; i++)
                {
                    LoadPicture(i);
                }
            }

            // 그외
            else
            {
                Debug.Log(request.downloadHandler.text);
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


    private void SettingReport()
    {
        GameObject reportImg = transform.Find($"ReportViewImg_{report.expIdx}").gameObject;
        reportImg.SetActive(true);
        transform.Find($"Score_{report.repScore}").gameObject.SetActive(true);

        // 날짜 세팅
        date = GameObject.Find("RepDate").GetComponent<Text>();
        date.text = report.repDate;

        for (int i = 0; i < 5; i++)
        {
            GameObject blank = reportImg.transform.GetChild(i).gameObject;
            if (total_answers[report.expIdx, i] != report.repAnswers[i])
            {
                blank.GetComponent<Outline>().effectColor = Color.red;
                blank.transform.GetChild(0).GetComponent<Text>().color = Color.red;
                reportImg.transform.Find($"ViewAnswer_{i}").GetChild(0).GetComponent<Text>().text = total_answers[report.expIdx, i];
            }
            blank.transform.GetChild(0).GetComponent<Text>().text = report.repAnswers[i];
        }
    }

    public void ToggleReportView()
    {
        transform.parent.gameObject.SetActive(!transform.parent.gameObject.activeSelf);
    }

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
}
