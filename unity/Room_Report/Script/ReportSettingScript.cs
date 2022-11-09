using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ReportSettingScript : MonoBehaviour
{
    private Text date;
    private Text username;

    public void Awake()
    {
        date = GameObject.Find("Date").GetComponent<Text>();
        username = GameObject.Find("Username").GetComponent<Text>();

        CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        date.text = DateTime.Now.ToString(string.Format($"yyyy�� MM�� dd�� ddd����", cultures));
        // username.text = PlayerPrefs.GetString("userId");
        username.text = "ȫ����";
    }


}
