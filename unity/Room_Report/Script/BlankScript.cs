using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BlankScript : MonoBehaviour
{
    private ReportSettingScript reportSettingScript;
    private Outline outline;
    public GameObject other;
    

    public void WhileHover()
    {
        reportSettingScript = other.GetComponent<ReportSettingScript>();

        // �������� �� ���°�, �̰� �� ĭ�� ���
        if (reportSettingScript.target != -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[2])] == -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.yellow;
        }

        // �������� ���� ���� ���°�, �̰� �� ĭ�� ���
        else if (reportSettingScript.target == -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[2])] != -1)
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
        // Ÿ�� ���� ����
        outline = GetComponent<Outline>();
        if (outline.effectColor == Color.red)
        {
            Text text = transform.GetChild(0).GetComponent<Text>();
            reportSettingScript = other.GetComponent<ReportSettingScript>();
            text.text = reportSettingScript.SelectBlank(Int32.Parse(name.Split("_")[2]));
            outline.effectColor = Color.black;
        }

        else if (outline.effectColor == Color.yellow)
        {
            Text text = transform.GetChild(0).GetComponent<Text>();
            reportSettingScript = other.GetComponent<ReportSettingScript>();
            text.text = reportSettingScript.SelectBlank(Int32.Parse(name.Split("_")[2]));
            outline.effectColor = Color.red;
        }
    }

}
