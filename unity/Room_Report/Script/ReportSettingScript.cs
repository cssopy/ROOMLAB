using System;
using System.Linq;
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

    // ��¥�� �̸�
    private Text date;
    private Text username;

    // ���� ����
    public int userIdx;

    // ���� ����
    public int expIdx;

    // �ܺ� Ŭ�� �� ����
    public GameObject shield;

    // ������ 10���� ��
    // 1. ���� ����
    // 2. �� ��â�� ���̸�Ż
    // 3. �Ҳ� ����
    // 4. ���� ũ�θ��� �׷���
    // 5. �ӱ� ���� ����
    // 6. �ڱ��� ����
    // 7. ȭ�� ���������� ���� ���� ��Ģ
    // 8. ������ ���� ����
    // 9. ü���� �п� ����
    // 10. �Ÿ� ����
    // 11. ���ö ���� (�̿�)

    private string[,] total_answers = new string[11, 10]
    {
        { "", "", "", "", "", "", "", "", "", "" },
        { "-", "������ ����", "����ü", "�� ��ġ", "+", "��ũ", "����ü", "������ ����", "������", "����" },
        { "��â", "�� ��â��", "ö", "����", "����", "���̸�Ż", "����", "�� ������", "���Ϸ�", "��ȭ" },
        { "��ȭ ��Ʈ��", "���� ����", "�����", "������", "Ȳ�ϻ�", "�Ķ���", "������", "���", "��ȭ Į��", "��ȭ ���׳׽�"},
        { "���ص�", "ũ�θ���׷���", "���� ����", "���", "����", "��ŵ�", "���ɺи���", "�µ�", "����", "����"},
        { "��ȭ ��", "���̿��� ȭ", "��", "���̿���ȭ ��", "�ӱ�","���� ��Ʈ��", "û�ϻ�", "��ȭ", "����", "��ȭ ����"},
        { "��", "��", "N", "S", "������", "��", "��", "E", "W", "�ݴ�Ǵ�"},
        { "���", "����", "����", "ź�� Į��", "���� ����", "�����", "�ִ�", "����", "ź�� Į��", "���� ���к�"},
        { "���", "�����ڸ�", "1.0", "0.2", "���� ���к�", "����", "���߾�", "0.8", "3.2", "��ü ����"},
        { "���� �ֱ�", "���� ��", "����ü", "����", "����", "�����", "�߱�", "�ı�", "������", "����"},
        { "��", "��ġ�� �ʵ���", "��ȭ ��Ʈ��", "����Ż��", "�Ÿ�", "ª��", "��ġ����", "����", "��Ʈ��", "ũ�θ���׷���" },
    };

    // ���� ������ ������
    private string[] answers = new string[10];

    // ���õ� ������ ����
    public int counts = 0;


    // ������ �ڽ� ������Ʈ
    public GameObject selection;


    // ���� �����
    public GameObject pictures;
    public PictureScript pictureScript;

    // ����Ʈ ���� ��Ʈ�ѷ�
    public GameObject other;
    public ReportController reportController;


    public void Awake()
    {
        // ���� ��ȣ
        expIdx = PlayerPrefs.GetInt("expIdx");
        // expIdx = 3;

        // ���� ����
        userIdx = PlayerPrefs.GetInt("userIdx");
        // userIdx = 1;

        // ��¥�� �̸� ����
        date = GameObject.Find("Date").GetComponent<Text>();
        username = GameObject.Find("Username").GetComponent<Text>();
        CultureInfo cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        date.text = DateTime.Now.ToString(string.Format($"yyyy�� MM�� dd�� ddd����", cultures));
        username.text = PlayerPrefs.GetString("userId");
        // username.text = "ȫ����";

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

    // ���� ���� �ݱ�
    public void ToggleReport()
    {
        // �Ʒ��� ������ ���� ����
        other.SetActive(true);

        transform.parent.gameObject.SetActive(false);
    }

    // ����Ʈ ����
    public void SaveUserReport()
    {
        reportController = other.GetComponent<ReportController>();
        List<string> repAnswers = new List<string> { };
        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] == -1)
            {
                repAnswers.Add("");
            }
            else
            {
                repAnswers.Add(answers[numbers[i]]);
            }
        }
        Report report = new Report()
        {
            userIdx = userIdx,
            expIdx = expIdx,
            repAnswers = repAnswers,
        };

        pictureScript = pictures.GetComponent<PictureScript>();
        reportController.SaveReport(report, pictureScript.selected);
    }
}
