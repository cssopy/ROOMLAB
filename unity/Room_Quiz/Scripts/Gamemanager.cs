using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class User
{
    public string userId;
    public string userPwd;
}

[System.Serializable]
public class Signup
{
    public string userId;
    public string userPwd;
    public string userGender;
}

[System.Serializable]
public class Check
{
    public string userId;
    public string refresh;
}

[System.Serializable]
public class Tutorial
{
    public string userId;
    public bool userTutorial;
}

public class Gamemanager : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IdInputField;
    public InputField PwInputField;
    public Text IdTxt;
    public Text TutoTxt;
    public Text IdTextField;
    public Text TutoTextField;
    public Button LoginButton;
    public Button LogoutButton;
    public Button CheckButton;
    public Button GoCreateAccountButton;
    //public Button GoDeleteAccountButton;
    public BoxCollider boxCollider;
    public GameObject Cube;

    [Header("CreateAccountPanel")]
    public InputField NewIdInputField;
    public InputField NewPwInputField;
    public TMP_Dropdown NewGenderDropdown;
    public Button CreateAccountButton;
    public Button CheckIdButton;
    public Button GoLoginButton;

    //[Header("DeleteAccountPanel")]
    //public InputField DelPwInputField;
    //public Button DeleteAccountButton;
    //public Button GoLogoutButton;

    public bool checkId = false;

    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider.isTrigger = false;
        //PlayerPrefs.DeleteAll();
        Debug.Log(PlayerPrefs.GetString("userId"));
        if (PlayerPrefs.HasKey("userId"))
        {
            IdInputField.gameObject.SetActive(false);
            PwInputField.gameObject.SetActive(false);
            LoginButton.gameObject.SetActive(false);
            GoCreateAccountButton.gameObject.SetActive(false);
            Cube.gameObject.SetActive(false);
            boxCollider.isTrigger = true;

            IdTextField.gameObject.SetActive(true);
            IdTextField.text = PlayerPrefs.GetString("userId");
            IdTxt.gameObject.SetActive(true);
            TutoTextField.gameObject.SetActive(true);
            TutoTxt.gameObject.SetActive(true);
            int tut = PlayerPrefs.GetInt("userTutorial");
            if (tut == 1)
            {
                TutoTextField.text = "O";
            }
            else if (tut == 0)
            {
                TutoTextField.text = "X";
            }
            CheckButton.gameObject.SetActive(true);
            LogoutButton.gameObject.SetActive(true);
        }
    }
    public void LoginBtn()
    {
        Debug.Log("�α��� ��ư Ŭ��");
        User user = new User
        {
            userId = IdInputField.text,
            userPwd = PwInputField.text
        };
        string json = JsonUtility.ToJson(user);
        string url = "https://k7d101.p.ssafy.io/api/user/login";

        StartCoroutine(LoginCo(url, json));
    }

    public void LogoutBtn()
    {
        Debug.Log("�α׾ƿ� ��ư Ŭ��");
        User user = new User
        {
            userId = PlayerPrefs.GetString("userId"),
            userPwd = PlayerPrefs.GetString("userPwd")
        };
        string json = JsonConvert.SerializeObject(user);
        string url = "https://k7d101.p.ssafy.io/api/user/logout";

        StartCoroutine(LogoutCo(url, json));
    }

    public void CheckIdBtn()
    {
        Debug.Log("���̵� �ߺ� üũ ��ư Ŭ��");

        string userId = NewIdInputField.text;

        string url = $"https://k7d101.p.ssafy.io/api/user/checkId/{userId}";

        StartCoroutine(CheckIdCo(url));
    }

    public void CreateAccountBtn()
    {
        if (!checkId)
        {
            Debug.Log("���̵� �ߺ� üũ ���ּ���!");
            return;
        }
        Debug.Log("ȸ������ ��ư Ŭ��");
        Signup user = new Signup
        {
            userId = NewIdInputField.text,
            userPwd = NewPwInputField.text,
            userGender = NewGenderDropdown.options[NewGenderDropdown.value].text
        };
        string json = JsonConvert.SerializeObject(user);
        string url = "https://k7d101.p.ssafy.io/api/user/signup";

        StartCoroutine(CreateAccountCo(url, json));
    }

    //public void DeleteAccountBtn()
    //{
    //    Debug.Log("ȸ��Ż�� ��ư Ŭ��");
    //    User user = new User
    //    {
    //        userId = PlayerPrefs.GetString("userId"),
    //        userPwd = DelPwInputField.text
    //    };
    //    string json = JsonConvert.SerializeObject(user);
    //    string url = "https://k7d101.p.ssafy.io/api/user/withdrawal";

    //    StartCoroutine(DeleteAccountCo(url, json));
    //}

    public void CheckTutorialBtn()
    {
        Debug.Log("Ʃ�丮�� ��ŵ ��ư Ŭ��");
        Tutorial tuto = new Tutorial
        {
            userId = PlayerPrefs.GetString("userId"),
            userTutorial = intToBool(PlayerPrefs.GetInt("userTutorial"))
        };
        string json = JsonConvert.SerializeObject(tuto);
        string url = "https://k7d101.p.ssafy.io/api/user/checkTutorial";

        StartCoroutine(CheckTutorialCo(url, json));
    }

    public void GoCreateAccountBtn()
    {
        Debug.Log("ȸ������ȭ�� �̵� ��ư Ŭ��");

        IdInputField.gameObject.SetActive(false);
        PwInputField.gameObject.SetActive(false);
        LoginButton.gameObject.SetActive(false);
        GoCreateAccountButton.gameObject.SetActive(false);

        NewIdInputField.text = "";
        NewPwInputField.text = "";

        NewIdInputField.gameObject.SetActive(true);
        NewPwInputField.gameObject.SetActive(true);
        CheckIdButton.gameObject.SetActive(true);
        NewGenderDropdown.gameObject.SetActive(true);
        CreateAccountButton.gameObject.SetActive(true);
        GoLoginButton.gameObject.SetActive(true);
    }

    public void GoLoginBtn()
    {
        Debug.Log("�α���ȭ�� �̵� ��ư Ŭ��");
        NewIdInputField.interactable = true;

        NewIdInputField.gameObject.SetActive(false);
        NewPwInputField.gameObject.SetActive(false);
        CheckIdButton.gameObject.SetActive(false);
        NewGenderDropdown.gameObject.SetActive(false);
        CreateAccountButton.gameObject.SetActive(false);
        GoLoginButton.gameObject.SetActive(false);

        checkId = false;
        IdInputField.text = "";
        PwInputField.text = "";

        IdInputField.gameObject.SetActive(true);
        PwInputField.gameObject.SetActive(true);
        LoginButton.gameObject.SetActive(true);
        GoCreateAccountButton.gameObject.SetActive(true);
    }

    //public void GoDeleteAccountBtn()
    //{
    //    Debug.Log("ȸ��Ż��ȭ�� �̵� ��ư Ŭ��");

    //    IdTxt.gameObject.SetActive(false);
    //    IdTextField.gameObject.SetActive(false);
    //    TutoTxt.gameObject.SetActive(false);
    //    TutoTextField.gameObject.SetActive(false);
    //    CheckButton.gameObject.SetActive(false);
    //    LogoutButton.gameObject.SetActive(false);
    //    GoDeleteAccountButton.gameObject.SetActive(false);

    //    DelPwInputField.text = "";

    //    DelPwInputField.gameObject.SetActive(true);
    //    DeleteAccountButton.gameObject.SetActive(true);
    //    GoLogoutButton.gameObject.SetActive(true);
    //}

    //public void GoLogoutBtn()
    //{
    //    Debug.Log("�α׾ƿ�ȭ�� �̵� ��ư Ŭ��");

    //    DelPwInputField.gameObject.SetActive(false);
    //    DeleteAccountButton.gameObject.SetActive(false);
    //    GoLogoutButton.gameObject.SetActive(false);

    //    IdTxt.gameObject.SetActive(true);
    //    IdTextField.gameObject.SetActive(true);
    //    TutoTxt.gameObject.SetActive(true);
    //    TutoTextField.gameObject.SetActive(true);
    //    CheckButton.gameObject.SetActive(true);
    //    LogoutButton.gameObject.SetActive(true);
    //    GoDeleteAccountButton.gameObject.SetActive(true);
    //}

    public int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    IEnumerator LoginCo(string url, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            // ���� ���̵�
            if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
                Debug.Log("���� ���̵��Դϴ�.");
            }
            // �߸��� ��й�ȣ
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // ����
            else if (request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);

                JObject obj = JObject.Parse(request.downloadHandler.text);
                PlayerPrefs.SetString("userId", IdInputField.text);
                PlayerPrefs.SetInt("userIdx", (int)obj["userIdx"]);
                PlayerPrefs.SetString("userGender", (string)obj["userGender"]);
                PlayerPrefs.SetInt("userTutorial", boolToInt((bool)obj["userTutorial"]));
                PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
                PlayerPrefs.SetString("refresh", (string)obj["refresh"]);

                IdTextField.text = PlayerPrefs.GetString("userId");
                int tut = PlayerPrefs.GetInt("userTutorial");
                if (tut == 1)
                {
                    TutoTextField.text = "O";
                }
                else if (tut == 0)
                {
                    TutoTextField.text = "X";
                }

                IdInputField.gameObject.SetActive(false);
                PwInputField.gameObject.SetActive(false);
                LoginButton.gameObject.SetActive(false);
                GoCreateAccountButton.gameObject.SetActive(false);

                Cube.gameObject.SetActive(false);
                boxCollider.isTrigger = true;

                IdTextField.gameObject.SetActive(true);
                IdTxt.gameObject.SetActive(true);
                TutoTextField.gameObject.SetActive(true);
                TutoTxt.gameObject.SetActive(true);
                CheckButton.gameObject.SetActive(true);
                LogoutButton.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator LogoutCo(string url, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", PlayerPrefs.GetString("access"));

            yield return request.SendWebRequest();

            // access ���� ��
            if (request.responseCode == 403)
            {
                Debug.Log("access ����");
                Debug.Log(request.error);
                Debug.Log(request.result);
                Check ck = new Check
                {
                    userId = PlayerPrefs.GetString("userId"),
                    refresh = PlayerPrefs.GetString("refresh")
                };
                Debug.Log("���� id : " + PlayerPrefs.GetString("userId"));
                Debug.Log("���� refresh : " + PlayerPrefs.GetString("refresh"));
                string checkJson = JsonConvert.SerializeObject(ck);

                using (UnityWebRequest req = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
                {
                    byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
                    req.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
                    req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                    req.SetRequestHeader("Content-Type", "application/json");

                    yield return req.SendWebRequest();

                    // refresh ���� ��
                    if (req.responseCode == 403)
                    {
                        Debug.Log("refresh ����");
                        Debug.Log(req.result);
                        Debug.Log(req.error);
                        PlayerPrefs.DeleteAll();

                        // �α��� ȭ������ ���ư���
                        //IdTxt.gameObject.SetActive(false);
                        //IdTextField.gameObject.SetActive(false);
                        //TutoTxt.gameObject.SetActive(false);
                        //TutoTextField.gameObject.SetActive(false);
                        //CheckButton.gameObject.SetActive(false);
                        //LogoutButton.gameObject.SetActive(false);
                        //GoDeleteAccountButton.gameObject.SetActive(false);

                        IdInputField.text = "";
                        PwInputField.text = "";

                        SceneManager.LoadScene("children_room");

                        //IdInputField.gameObject.SetActive(true);
                        //PwInputField.gameObject.SetActive(true);
                        //LoginButton.gameObject.SetActive(true);
                        //GoCreateAccountButton.gameObject.SetActive(true);
                    }
                    // �ش� ������ ��ū�� �ƴ� ��
                    else if (req.responseCode == 400)
                    {
                        Debug.Log(req.downloadHandler.text);
                    }
                    // ����
                    else if (req.responseCode == 200)
                    {
                        Debug.Log("refresh ���� �ƴϱ⶧���� access ��߱�");
                        Debug.Log(req.downloadHandler.text);

                        JObject obj = JObject.Parse(req.downloadHandler.text);
                        PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
                        Debug.Log("��߱� ���� access : " + PlayerPrefs.GetString("access"));
                    }
                }
            }
            // �߸��� ���̵�
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // �̹� �α׾ƿ��� ����
            else if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // ����
            else if (request.responseCode == 200)
            {
                Debug.Log("access ���� �ƴϱ⶧���� �α׾ƿ� ����");
                Debug.Log(request.downloadHandler.text);
                checkId = false;
                PlayerPrefs.DeleteAll();

                //IdTextField.gameObject.SetActive(false);
                //IdTxt.gameObject.SetActive(false);
                //TutoTextField.gameObject.SetActive(false);
                //TutoTxt.gameObject.SetActive(false);
                //CheckButton.gameObject.SetActive(false);
                //LogoutButton.gameObject.SetActive(false);

                IdInputField.text = "";
                PwInputField.text = "";

                //IdInputField.gameObject.SetActive(true);
                //PwInputField.gameObject.SetActive(true);
                //LoginButton.gameObject.SetActive(true);
                //Cube.gameObject.SetActive(true);
                //boxCollider.isTrigger = false;
                //GoCreateAccountButton.gameObject.SetActive(true);
                Debug.Log("�ε� ������");
                SceneManager.LoadScene("children_room");
                Debug.Log("�ε� ������");
            }
        }
    }

    IEnumerator CheckIdCo(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            // �ߺ��� ���̵�
            if (request.responseCode == 409)
            {
                Debug.Log(request.downloadHandler.text);
                NewIdInputField.text = "";
            }
            // ����
            else if (request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);
                NewIdInputField.interactable = false;
                checkId = true;
            }
        }
    }

    IEnumerator CreateAccountCo(string url, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            // �ߺ��� ���̵�
            if (request.responseCode == 409)
            {
                Debug.Log(request.error);
                Debug.Log("�ߺ��� ���̵��Դϴ�.");
            }
            // �߸��� ���̵�, ���
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // ����
            else if (request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);
                NewIdInputField.interactable = true;

                NewIdInputField.gameObject.SetActive(false);
                NewPwInputField.gameObject.SetActive(false);
                CheckIdButton.gameObject.SetActive(false);
                NewGenderDropdown.gameObject.SetActive(false);
                CreateAccountButton.gameObject.SetActive(false);
                GoLoginButton.gameObject.SetActive(false);

                IdInputField.text = "";
                PwInputField.text = "";

                IdInputField.gameObject.SetActive(true);
                PwInputField.gameObject.SetActive(true);
                LoginButton.gameObject.SetActive(true);
                GoCreateAccountButton.gameObject.SetActive(true);
            }
        }
    }

    //IEnumerator DeleteAccountCo(string url, string json)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Post(url, json))
    //    {
    //        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
    //        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
    //        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //        request.SetRequestHeader("Content-Type", "application/json");
    //        request.SetRequestHeader("Authorization", PlayerPrefs.GetString("access"));

    //        yield return request.SendWebRequest();

    //        // access ���� ��
    //        if (request.responseCode == 403)
    //        {
    //            Debug.Log("access ����");
    //            Debug.Log(request.error);
    //            Debug.Log(request.result);
    //            Check ck = new Check
    //            {
    //                userId = PlayerPrefs.GetString("userId"),
    //                refresh = PlayerPrefs.GetString("refresh")
    //            };
    //            Debug.Log("���� id : " + PlayerPrefs.GetString("userId"));
    //            Debug.Log("���� refresh : " + PlayerPrefs.GetString("refresh"));
    //            string checkJson = JsonConvert.SerializeObject(ck);

    //            using (UnityWebRequest req = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
    //            {
    //                byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
    //                req.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
    //                req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //                req.SetRequestHeader("Content-Type", "application/json");

    //                yield return req.SendWebRequest();

    //                // refresh ���� ��
    //                if (req.responseCode == 403)
    //                {
    //                    Debug.Log("refresh ����");
    //                    Debug.Log(req.result);
    //                    Debug.Log(req.error);
    //                    PlayerPrefs.DeleteAll();

    //                    // �α��� ȭ������ ���ư���
    //                    DelPwInputField.gameObject.SetActive(false);
    //                    DeleteAccountButton.gameObject.SetActive(false);
    //                    GoLogoutButton.gameObject.SetActive(false);

    //                    IdInputField.text = "";
    //                    PwInputField.text = "";

    //                    IdInputField.gameObject.SetActive(true);
    //                    PwInputField.gameObject.SetActive(true);
    //                    LoginButton.gameObject.SetActive(true);
    //                    GoCreateAccountButton.gameObject.SetActive(true);
    //                }
    //                // �ش� ������ ��ū�� �ƴ� ��
    //                else if (req.responseCode == 400)
    //                {
    //                    Debug.Log(req.downloadHandler.text);
    //                }
    //                // ����
    //                else if (req.responseCode == 200)
    //                {
    //                    Debug.Log("refresh ���� �ƴϱ⶧���� access ��߱�");
    //                    Debug.Log(req.downloadHandler.text);

    //                    JObject obj = JObject.Parse(req.downloadHandler.text);
    //                    PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
    //                    Debug.Log("��߱� ���� access : " + PlayerPrefs.GetString("access"));
    //                }
    //            }
    //        }
    //        // �߸��� ��й�ȣ
    //        else if (request.responseCode == 400)
    //        {
    //            Debug.Log(request.downloadHandler.text);
    //            DelPwInputField.text = "";
    //        }
    //        // ���� �����
    //        else if (request.responseCode == 404)
    //        {
    //            Debug.Log(request.downloadHandler.text);
    //        }
    //        // ����
    //        else if (request.responseCode == 200)
    //        {
    //            Debug.Log("Ż�� ����");
    //            Debug.Log(request.downloadHandler.text);
    //            PlayerPrefs.DeleteAll();

    //            DelPwInputField.gameObject.SetActive(false);
    //            DeleteAccountButton.gameObject.SetActive(false);
    //            GoLogoutButton.gameObject.SetActive(false);

    //            IdInputField.text = "";
    //            PwInputField.text = "";

    //            IdInputField.gameObject.SetActive(true);
    //            PwInputField.gameObject.SetActive(true);
    //            LoginButton.gameObject.SetActive(true);
    //            GoCreateAccountButton.gameObject.SetActive(true);
    //        }
    //    }
    //}

    IEnumerator CheckTutorialCo(string url, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", PlayerPrefs.GetString("access"));

            yield return request.SendWebRequest();

            // access ����
            if (request.responseCode == 403)
            {
                Debug.Log(request.downloadHandler.text);
                Debug.Log(request.result);
                Debug.Log(request.error);
                Check ck = new Check
                {
                    userId = PlayerPrefs.GetString("userId"),
                    refresh = PlayerPrefs.GetString("refresh")
                };
                Debug.Log("���� id : " + PlayerPrefs.GetString("userId"));
                Debug.Log("���� refresh : " + PlayerPrefs.GetString("refresh"));
                string checkJson = JsonConvert.SerializeObject(ck);

                using (UnityWebRequest req = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
                {
                    byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
                    req.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
                    req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                    req.SetRequestHeader("Content-Type", "application/json");

                    yield return req.SendWebRequest();

                    // refresh ����
                    if (req.responseCode == 403)
                    {
                        Debug.Log("refresh ����");
                        Debug.Log(req.result);
                        Debug.Log(req.error);
                        PlayerPrefs.DeleteAll();

                        // �α��� ȭ������ ���ư���
                        //IdTxt.gameObject.SetActive(false);
                        //IdTextField.gameObject.SetActive(false);
                        //TutoTxt.gameObject.SetActive(false);
                        //TutoTextField.gameObject.SetActive(false);
                        //CheckButton.gameObject.SetActive(false);
                        //LogoutButton.gameObject.SetActive(false);
                        ////GoDeleteAccountButton.gameObject.SetActive(false);

                        IdInputField.text = "";
                        PwInputField.text = "";
                        SceneManager.LoadScene("children_room");

                        //IdInputField.gameObject.SetActive(true);
                        //PwInputField.gameObject.SetActive(true);
                        //LoginButton.gameObject.SetActive(true);
                        //GoCreateAccountButton.gameObject.SetActive(true);
                    }
                    // �ش� ������ ��ū�� �ƴ� ��
                    else if (req.responseCode == 400)
                    {
                        Debug.Log(req.downloadHandler.text);
                    }
                    // ����
                    else if (req.responseCode == 200)
                    {
                        Debug.Log("refresh ���� �ƴϱ⶧���� access ��߱�");
                        Debug.Log(req.downloadHandler.text);

                        JObject obj = JObject.Parse(req.downloadHandler.text);
                        PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
                        Debug.Log("��߱� ���� access : " + PlayerPrefs.GetString("access"));
                    }
                }
            }
            // ���� �����
            else if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // ����
            else if (request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);

                int tut = PlayerPrefs.GetInt("userTutorial");
                if (tut == 1)
                {
                    PlayerPrefs.SetInt("userTutorial", 0);
                    TutoTextField.text = "X";
                }
                else if (tut == 0)
                {
                    PlayerPrefs.SetInt("userTutorial", 1);
                    TutoTextField.text = "O";
                }
            }
        }
    }
}
