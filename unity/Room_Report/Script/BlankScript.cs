using System;
using UnityEngine;
using UnityEngine.UI;

public class BlankScript : MonoBehaviour
{
    private ReportSettingScript reportSettingScript;
    private Outline outline;
    public GameObject other;


    private void Awake()
    {
        reportSettingScript = other.GetComponent<ReportSettingScript>();
    }

    public void WhileHover()
    {

        // �������� �� ���°�, �̰� �� ĭ�� ���
        if (reportSettingScript.target != -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[1])] == -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.yellow;
        }

        // �������� ���� ���� ���°�, �̰� �� ĭ�� ���
        else if (reportSettingScript.target == -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[1])] != -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.red;
        }
    }

    public void WhenLeave()
    {
        // �⺻ ������
        reportSettingScript = other.GetComponent<ReportSettingScript>();
        outline = GetComponent<Outline>();
        outline.effectColor = Color.black;
    }

    public void WhenClicked()
    {
        // 1. ����� �� ����
        outline = GetComponent<Outline>();
        if (outline.effectColor == Color.red)
        {
            Text text = transform.GetChild(0).GetComponent<Text>();
            reportSettingScript = other.GetComponent<ReportSettingScript>();
            text.text = reportSettingScript.SelectBlank(Int32.Parse(name.Split("_")[1]));
            outline.effectColor = Color.black;
        }

        // 2. ���ο� �� ����
        else if (outline.effectColor == Color.yellow)
        {
            Text text = transform.GetChild(0).GetComponent<Text>();
            reportSettingScript = other.GetComponent<ReportSettingScript>();
            text.text = reportSettingScript.SelectBlank(Int32.Parse(name.Split("_")[1]));
            outline.effectColor = Color.red;
        }
    }

}
