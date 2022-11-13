using System;
using System.Linq;
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

    // �ܺ� Ŭ�� �� ����
    public GameObject shield;

    // ������ 10���� ��
    // 0. ���� ����
    // 1. �� ��â�� ���̸�Ż
    // 2. �Ҳ� ����
    // 3. ���� ũ�θ��� �׷���
    // 4. �ӱ� ���� ����
    // 5. �ڱ��� ����
    // 6. ȭ�� ���������� ���� ���� ��Ģ
    // 7. ������ ���� ����
    // 8. ü���� �п� ����
    // 9. �Ÿ� ���� (�̿�)
    // 10. ���ö ���� (�̿�)

    private string[,] total_answers = new string[9, 10]
    {
        { "-", "������ ����", "����ü", "�� ��ġ", "+", "��ũ", "����ü", "������ ����", "������", "����" },
        { "��â", "�� ��â��", "ö", "����", "����", "���̸�Ż", "����", "�� ������", "���Ϸ�", "��ȭ" },
        { "��ȭ ��Ʈ��", "���� ����", "�����", "������", "Ȳ�ϻ�", "�Ķ���", "������", "���", "��ȭ Į��", "��ȭ ���׳׽�"},
        { "���ص�", "ũ�θ���׷���", "���� ����", "���", "����", "��ŵ�", "���ɺи���", "�µ�", "����", "����"},
        { "��ȭ ��", "���", "���̿��� ȭ", "��", " ���̿���ȭ ��", "���� ��Ʈ��", "û�ϻ�", "��ȭ", "����", "��ȭ ����"},
        { "��", "��", "N", "S", "������", "��", "��", "E", "W", "�ݴ�Ǵ�"},
        { "���", "����", "����", "ź�� Į��", "���� ����", "�����", "�ִ�", "����", "ź�� Į��", "���� ���к�"},
        { "���", "�����ڸ�", "1.0", "0.2", "���� ���к�", "����", "���߾�", "0.8", "3.2", "��ü ����"},
        { "���� �ֱ�", "���� ��", "����ü", "����", "����", "�����", "�߱�", "�ı�", "������", "����"},
    };

    // ���� ������ ������
    private string[] answers = new string[10];

    // ���õ� ������ ����
    public int counts = 0;


    // ������ �ڽ� ������Ʈ
    public GameObject selection;


    public void Awake()
    {
        // ���� ��ȣ
        // expIdx = PlayerPrefs.GetInt("expIdx");
        expIdx = 1;

        // ��¥�� �̸� ����
        date = GameObject.Find("Date").GetComponent<Text>();
        username = GameObject.Find("Username").GetComponent<Text>();
        CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        date.text = DateTime.Now.ToString(string.Format($"yyyy�� MM�� dd�� ddd����", cultures));
        // username.text = PlayerPrefs.GetString("userId");
        username.text = "ȫ����";

        // ���� ���� Ȱ��ȭ
        transform.Find($"ReportImg_{expIdx}").gameObject.SetActive(true);

        // ���� �� ����ȭ
        for (int i = 0; i < 10; i++)
        {
            answers[i] = total_answers[expIdx, i];
        }
        System.Random random = new System.Random();
        answers = answers.OrderBy(x => random.Next()).ToArray();

        // ���� �Ѹ���
        for (int j = 0; j < 10; j++)
        {
            selection.transform.GetChild(j).transform.GetComponentInChildren<Text>().text = answers[j];
        }

    }


    public void SelectAnswer(int t)
    {
        // 1. �Ȱ��� ���� �������� �� �� ���� ��Ȳ�� ��� ��ư ����
        if (target == t)
        {
            selection.transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.yellow;
            target = -1;
            shield.SetActive(false);
        }

        // 2. ���� �ٸ� ��ư�ε� ���� ���� ������ �׳� �ֱ�
        else if (target == -1)
        {
            shield.SetActive(true);
            target = t;
        }

        // 3. �ܺ� Ŭ���� ���� ���
        else if (t == -1)
        {
            shield.SetActive(false);
            selection.transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.white;
            target = -1;

        }

        // 4. ���� ���� ������
        else
        {
            selection.transform.Find($"Answer_{target}").GetComponent<Outline>().effectColor = Color.white;
            target = t;
        }

    }

    public string SelectBlank(int m)
    {
        // 1. �� �ڸ��� �� �ֱ�
        if (numbers[m] == -1)
        {
            // ����� & �� ����
            GameObject obj = selection.transform.Find($"Answer_{target}").gameObject;
            obj.SetActive(false);
            obj.GetComponent<Outline>().effectColor = Color.white;
            
            // ���� ä���
            numbers[m] = target;

            // �ʱ�ȭ
            target = -1;

            // ī��Ʈ ����
            counts++;

            // ������Ʈ ����
            shield.SetActive(false);

            // �� �ֱ�
            return answers[numbers[m]];
        }

        // 2, �� �ִ� �� ����
        else
        {
            // Ȱ��ȭ
            selection.transform.Find($"Answer_{numbers[m]}").gameObject.SetActive(true);
            
            // ���� �ʱ�ȭ
            numbers[m] = -1;

            // ī��Ʈ ����
            counts--;

            // �� �ֱ�
            return "";

        }
    }
}
