using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ReportSettingScript : MonoBehaviour
{
    // 10�� �ڽ��� ����
    private string[] answers = new string[10];
    // �ش� ��ġ�� �ִ� �� �ε���
    private int[] numbers = new int[5] { -1, -1, -1, -1, -1 };
    // 10���� �ڽ��� ���� ��ġ
    public Vector3[] positions = new Vector3[10];
    // 5���� ��ĭ�� ���� ��ġ
    private Vector3[] blanks = new Vector3[5];
    // ���� Ÿ���õ� �ڽ�
    public int target = -1;
    // ��¥�� �ð�
    private Text date;
    private Text username;
    
    // ��Ÿ ����
    private GameObject obj;
    private GameObject obj2;


    public void Awake()
    {
        // ��¥�� �̸� ����
        date = GameObject.Find("Date").GetComponent<Text>();
        username = GameObject.Find("Username").GetComponent<Text>();
        CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        date.text = DateTime.Now.ToString(string.Format($"yyyy�� MM�� dd�� ddd����", cultures));
        // username.text = PlayerPrefs.GetString("userId");
        username.text = "ȫ����";

        // �� ĭ���� ��ǥ �޾ƿͼ� ���
        for (int i = 0; i < 5; i++)
        {
            obj = GameObject.Find($"Blank_{i}");
            blanks[i] = obj.transform.position;
        }
    }

    // Ÿ���� �� ��ĭ ����
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
            // Ÿ������ ��ġ�� �ٲ�� ��
            // 1. ������ �ִ� ���� ������, �� ���� ���� ��ġ�� �ű��
            if (numbers[target] != -1)
            {
                int m = numbers[target];
                obj2 = transform.Find($"Answer_{m}").gameObject;
                obj2.transform.position = positions[m];
            }

            // 2. �� �ڸ��� ���� �ֱ�
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
