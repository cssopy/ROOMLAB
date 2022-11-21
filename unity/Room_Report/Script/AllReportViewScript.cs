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
    // ���� �ִ� ����Ʈ�� �ε���
    private int targetIdx = 0;

    // ���� ���� Idx
    private int userIdx;

    // ��� ���� ���
    private List<AllReport> reports;

    // ���� ������ ���� ���
    private List<AllPicture> pictures;

    // ������ ��� ���� ������Ʈ ���
    public GameObject[] ReportPics = new GameObject[5];

    // ���� ũ�� �����ִ� â
    public GameObject PicPreview;

    // ��¥�� �̸�
    private Text date;
    private Text username;

    // ���������̼�
    private int pageIdx = 0;

    // ���� ����Ʈ ��Ʈ
    public GameObject board;

    // �ؽ��� �ҷ� �� ���� ��ϵ�
    public List<Texture2D> textures = new List<Texture2D>();

    // ��ū
    private string token;


    private string[,] total_answers = new string[11, 5]
    {
        { "", "", "", "", ""},
        { "-", "������ ����", "����ü", "�� ��ġ", "+" },
        { "��â", "�� ��â��", "ö", "����", "����" },
        { "��ȭ ��Ʈ��", "���� ����", "�����", "������", "Ȳ�ϻ�"},
        { "���ص�", "ũ�θ���׷���", "���� ����", "���", "����"},
        { "��ȭ ��", "���̿��� ȭ", "��", " ���̿���ȭ ��", "�ӱ�"},
        { "��", "��", "N", "S", "������"},
        { "���", "����", "����", "ź�� Į��", "���� ����"},
        { "���", "�����ڸ�", "1.0", "0.2", "���� ���к�"},
        { "���� �ֱ�", "���� ��", "����ü", "����", "����"},
        { "��", "��ġ�� �ʵ���", "��ȭ ��Ʈ��", "����Ż��", "�Ÿ�"},
    };

    public void OnEnable()
    {
        // ����� Idx
        userIdx = PlayerPrefs.GetInt("userIdx");
        // userIdx = 1;

        // �̸� ����
        username = GameObject.Find("RepUsername").GetComponent<Text>();
        username.text = PlayerPrefs.GetString("userId");
        // username.text = "ȫ����";

        FindAllReport();
    }

    // ��ü ���� ��� �ҷ�����
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


            // refresh �����
            if (request.responseCode == 403)
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadSceneAsync("children_room");
            }

            // �ش� ������ ��ū�� �ƴ� ��
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // ���� (Access ��߱�)
            else if (request.responseCode == 200)
            {
                JObject obj = JObject.Parse(request.downloadHandler.text);
                token = "Bearer " + (string)obj["access"];
                PlayerPrefs.SetString("access", token);
                StartCoroutine(FindAllRepCo(url));
            }
        }
    }

    // ���� ��ü ã�ƿ��� �Լ�
    IEnumerator FindAllRepCo(string url)
    {

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {

            request.SetRequestHeader("Authorization", "Bearer " + token);
            yield return request.SendWebRequest();

            // ����
            if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // access ����
            else if (request.responseCode == 403)
            {
                StartCoroutine(CheckRefreshAllReport(url));
            }

            // �ش� ������ ��ū�� �ƴ� ��
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }

            // ����
            else if (request.responseCode == 200)
            {
                reports = JsonUtility.FromJson<UserAllReport>(request.downloadHandler.text).reports;
                
                // ����Ʈ ����Ʈ ����
                SettingReportList();

                // �⺻ ������ 0�� ����Ʈ ����
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

    // �������� ���� ����Ʈ ��� ����
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


    // �Է� ������ ����Ʈ ����
    public void SettingReport(int r)
    {
        // ���� ���� ����
        transform.Find($"ReportViewImg_{reports[targetIdx].expIdx}").gameObject.SetActive(false);
        transform.Find($"Score_{reports[targetIdx].repScore}").gameObject.SetActive(false);

        targetIdx = r + pageIdx * 12;

        // �̹� ���� Ű��
        GameObject reportImg = transform.Find($"ReportViewImg_{reports[targetIdx].expIdx}").gameObject;
        reportImg.SetActive(true);
        transform.Find($"Score_{reports[targetIdx].repScore}").gameObject.SetActive(true);


        // ��¥ ����
        date = GameObject.Find("RepDate").GetComponent<Text>();
        date.text = reports[targetIdx].repDate;


        // ��ĭ ����
        for (int i = 0; i < 5; i++)
        {
            // ����� ������ ����
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

        // ���� ȣ��
        pictures = reports[targetIdx].pictures;
        for (int j = 0; j < pictures.Count; j++)
        {
            LoadPicture(j);
        }
    }

    // ����Ʈ Ȯ�� Ű�� ��ư �Ǵ� �ݴ� ��ư
    public void ToggleReportView()
    {
        transform.parent.gameObject.SetActive(!transform.parent.gameObject.activeSelf);
        board.transform.parent.gameObject.SetActive(!board.transform.parent.gameObject.activeSelf);
    }

    // ���� �̸����� �� ����
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

    // ������ �̵�
    public void Pagination(int p)
    {
        pageIdx += p;
        SettingReportList();
    }
}
