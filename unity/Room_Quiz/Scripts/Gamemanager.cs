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
        Debug.Log("로그인 버튼 클릭");
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
        Debug.Log("로그아웃 버튼 클릭");
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
        Debug.Log("아이디 중복 체크 버튼 클릭");

        string userId = NewIdInputField.text;

        string url = $"https://k7d101.p.ssafy.io/api/user/checkId/{userId}";

        StartCoroutine(CheckIdCo(url));
    }

    public void CreateAccountBtn()
    {
        if (!checkId)
        {
            Debug.Log("아이디 중복 체크 해주세요!");
            return;
        }
        Debug.Log("회원가입 버튼 클릭");
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
    //    Debug.Log("회원탈퇴 버튼 클릭");
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
        Debug.Log("튜토리얼 스킵 버튼 클릭");
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
        Debug.Log("회원가입화면 이동 버튼 클릭");

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
        Debug.Log("로그인화면 이동 버튼 클릭");
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
    //    Debug.Log("회원탈퇴화면 이동 버튼 클릭");

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
    //    Debug.Log("로그아웃화면 이동 버튼 클릭");

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

            // 없는 아이디
            if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
                Debug.Log("없는 아이디입니다.");
            }
            // 잘못된 비밀번호
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // 성공
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

            // access 만료 시
            if (request.responseCode == 403)
            {
                Debug.Log("access 만료");
                Debug.Log(request.error);
                Debug.Log(request.result);
                Check ck = new Check
                {
                    userId = PlayerPrefs.GetString("userId"),
                    refresh = PlayerPrefs.GetString("refresh")
                };
                Debug.Log("보낼 id : " + PlayerPrefs.GetString("userId"));
                Debug.Log("보낼 refresh : " + PlayerPrefs.GetString("refresh"));
                string checkJson = JsonConvert.SerializeObject(ck);

                using (UnityWebRequest req = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
                {
                    byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
                    req.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
                    req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                    req.SetRequestHeader("Content-Type", "application/json");

                    yield return req.SendWebRequest();

                    // refresh 만료 시
                    if (req.responseCode == 403)
                    {
                        Debug.Log("refresh 만료");
                        Debug.Log(req.result);
                        Debug.Log(req.error);
                        PlayerPrefs.DeleteAll();

                        // 로그인 화면으로 돌아가기
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
                    // 해당 유저의 토큰이 아닐 때
                    else if (req.responseCode == 400)
                    {
                        Debug.Log(req.downloadHandler.text);
                    }
                    // 성공
                    else if (req.responseCode == 200)
                    {
                        Debug.Log("refresh 만료 아니기때문에 access 재발급");
                        Debug.Log(req.downloadHandler.text);

                        JObject obj = JObject.Parse(req.downloadHandler.text);
                        PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
                        Debug.Log("재발급 받은 access : " + PlayerPrefs.GetString("access"));
                    }
                }
            }
            // 잘못된 아이디
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // 이미 로그아웃된 상태
            else if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // 성공
            else if (request.responseCode == 200)
            {
                Debug.Log("access 만료 아니기때문에 로그아웃 성공");
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
                Debug.Log("로딩 시작전");
                SceneManager.LoadScene("children_room");
                Debug.Log("로딩 시작후");
            }
        }
    }

    IEnumerator CheckIdCo(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            // 중복된 아이디
            if (request.responseCode == 409)
            {
                Debug.Log(request.downloadHandler.text);
                NewIdInputField.text = "";
            }
            // 성공
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

            // 중복된 아이디
            if (request.responseCode == 409)
            {
                Debug.Log(request.error);
                Debug.Log("중복된 아이디입니다.");
            }
            // 잘못된 아이디, 비번
            else if (request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // 성공
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

    //        // access 만료 시
    //        if (request.responseCode == 403)
    //        {
    //            Debug.Log("access 만료");
    //            Debug.Log(request.error);
    //            Debug.Log(request.result);
    //            Check ck = new Check
    //            {
    //                userId = PlayerPrefs.GetString("userId"),
    //                refresh = PlayerPrefs.GetString("refresh")
    //            };
    //            Debug.Log("보낼 id : " + PlayerPrefs.GetString("userId"));
    //            Debug.Log("보낼 refresh : " + PlayerPrefs.GetString("refresh"));
    //            string checkJson = JsonConvert.SerializeObject(ck);

    //            using (UnityWebRequest req = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
    //            {
    //                byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
    //                req.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
    //                req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //                req.SetRequestHeader("Content-Type", "application/json");

    //                yield return req.SendWebRequest();

    //                // refresh 만료 시
    //                if (req.responseCode == 403)
    //                {
    //                    Debug.Log("refresh 만료");
    //                    Debug.Log(req.result);
    //                    Debug.Log(req.error);
    //                    PlayerPrefs.DeleteAll();

    //                    // 로그인 화면으로 돌아가기
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
    //                // 해당 유저의 토큰이 아닐 때
    //                else if (req.responseCode == 400)
    //                {
    //                    Debug.Log(req.downloadHandler.text);
    //                }
    //                // 성공
    //                else if (req.responseCode == 200)
    //                {
    //                    Debug.Log("refresh 만료 아니기때문에 access 재발급");
    //                    Debug.Log(req.downloadHandler.text);

    //                    JObject obj = JObject.Parse(req.downloadHandler.text);
    //                    PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
    //                    Debug.Log("재발급 받은 access : " + PlayerPrefs.GetString("access"));
    //                }
    //            }
    //        }
    //        // 잘못된 비밀번호
    //        else if (request.responseCode == 400)
    //        {
    //            Debug.Log(request.downloadHandler.text);
    //            DelPwInputField.text = "";
    //        }
    //        // 없는 사용자
    //        else if (request.responseCode == 404)
    //        {
    //            Debug.Log(request.downloadHandler.text);
    //        }
    //        // 성공
    //        else if (request.responseCode == 200)
    //        {
    //            Debug.Log("탈퇴 성공");
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

            // access 만료
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
                Debug.Log("보낼 id : " + PlayerPrefs.GetString("userId"));
                Debug.Log("보낼 refresh : " + PlayerPrefs.GetString("refresh"));
                string checkJson = JsonConvert.SerializeObject(ck);

                using (UnityWebRequest req = UnityWebRequest.Post("https://k7d101.p.ssafy.io/api/user/check", checkJson))
                {
                    byte[] checkJsonToSend = new System.Text.UTF8Encoding().GetBytes(checkJson);
                    req.uploadHandler = new UploadHandlerRaw(checkJsonToSend);
                    req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                    req.SetRequestHeader("Content-Type", "application/json");

                    yield return req.SendWebRequest();

                    // refresh 만료
                    if (req.responseCode == 403)
                    {
                        Debug.Log("refresh 만료");
                        Debug.Log(req.result);
                        Debug.Log(req.error);
                        PlayerPrefs.DeleteAll();

                        // 로그인 화면으로 돌아가기
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
                    // 해당 유저의 토큰이 아닐 때
                    else if (req.responseCode == 400)
                    {
                        Debug.Log(req.downloadHandler.text);
                    }
                    // 성공
                    else if (req.responseCode == 200)
                    {
                        Debug.Log("refresh 만료 아니기때문에 access 재발급");
                        Debug.Log(req.downloadHandler.text);

                        JObject obj = JObject.Parse(req.downloadHandler.text);
                        PlayerPrefs.SetString("access", "Bearer " + (string)obj["access"]);
                        Debug.Log("재발급 받은 access : " + PlayerPrefs.GetString("access"));
                    }
                }
            }
            // 없는 사용자
            else if (request.responseCode == 404)
            {
                Debug.Log(request.downloadHandler.text);
            }
            // 성공
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
