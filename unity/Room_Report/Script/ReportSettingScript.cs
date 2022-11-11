using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class ReportSettingScript : MonoBehaviour
{


    // �ش� ��ġ�� �ִ� �� �ε���
    public int[] numbers = new int[5] { -1, -1, -1, -1, -1 };

    // ���� Ÿ���õ� ������
    public int target = -1;

    // ��¥�� �ð�
    private Text date;
    private Text username;

    // ���� ����
    private int expIdx;

    System.Random random = new System.Random();

    // 1. ������ 10���� ��
    private string[,] answers = new string[3, 10];
//    {
//        { "������ ����", "+", "-", "����ü", "�� ��ġ", "��ũ", "����", "����ü", "������ ����", "������" }.OrderBy(x => random.Next()).ToArray(),
//        { "�����ڸ�", "0.2", "���", "3.2", "���߾�", "����", "1.0", "��ü ������", "0.8", "���� ���к�" },
//        { "��ȭ ��Ʈ��", "��ȭ Į��", "���", "���� ����", "������", "������", "��ȭ ���׳׽�", "�����", "1", "2"},
//    };
    // 0. ���� ����
    // 1. ���� ���� ����
    // 2. 

    
    // 2. Ȱ��ȭ ��ų ��ĭ�� -> ��� Awake���� �Լ��� ����


    public void Awake()
    {
        // ���� ��ȣ
        // expIdx = PlayerPrefs.GetInt("expIdx");
        expIdx = 0;

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
            transform.Find($"Blank_{expIdx}_{i}").gameObject.SetActive(true);
        }

       
    }

    // Ÿ���� �� ��ĭ ����

    public string SetAnswers(int n, int m)
    {
        return answers[n,m];
    }

    public void SelectAnswer(int t)
    {
        // 1. �Ȱ��� ���� �������� �� �� ���� ��Ȳ�� ��� ��ư ����
        if (target == t)
        {
            transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.yellow;
            target = -1;
        }

        // 2. ���� �ٸ� ��ư�ε� ���� ���� ������ �׳� �ֱ�
        else if (target == -1)
        {
            target = t;
        }

        // 3. ���� ���� ������
        else
        {
            transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.white;
            target = t;
        }

    }

    public string SelectBlank(int m)
    {
        // 1. �� �ڸ��� �� �ֱ�
        if (numbers[m] == -1)
        {
            // ����� & �� ����
            GameObject obj = transform.Find($"Answer_{target}").gameObject;
            obj.SetActive(false);
            obj.GetComponent<Outline>().effectColor = Color.white;
            
            // ���� ä���
            numbers[m] = target;

            // �ʱ�ȭ
            target = -1;

            // �� �ֱ�
            return answers[expIdx, numbers[m]];
        }

        // 2, �� �ִ� �� ����
        else
        {
            // Ȱ��ȭ
            transform.Find($"Answer_{numbers[m]}").gameObject.SetActive(true);
            
            // ���� �ʱ�ȭ
            numbers[m] = -1;

            // �� �ֱ�

            return "";

        }
    }
}
