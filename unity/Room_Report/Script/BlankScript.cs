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

        // 선택지를 고른 상태고, 이게 빈 칸인 경우
        if (reportSettingScript.target != -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[2])] == -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.yellow;
        }

        // 선택지를 고르지 않은 상태고, 이게 찬 칸인 경우
        else if (reportSettingScript.target == -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[2])] != -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.red;
        }
    }

    public void WhenLeave()
    {
        // 기본 값으로
        reportSettingScript = other.GetComponent<ReportSettingScript>();
        outline = GetComponent<Outline>();
        outline.effectColor = Color.black;
    }

    public void WhenClicked()
    {
        // 타겟 값을 저장
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
