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

        // 선택지를 고른 상태고, 이게 빈 칸인 경우
        if (reportSettingScript.target != -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[1])] == -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.yellow;
        }

        // 선택지를 고르지 않은 상태고, 이게 찬 칸인 경우
        else if (reportSettingScript.target == -1 && reportSettingScript.numbers[Int32.Parse(name.Split("_")[1])] != -1)
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
        // 1. 저장된 값 빼기
        outline = GetComponent<Outline>();
        if (outline.effectColor == Color.red)
        {
            Text text = transform.GetChild(0).GetComponent<Text>();
            reportSettingScript = other.GetComponent<ReportSettingScript>();
            text.text = reportSettingScript.SelectBlank(Int32.Parse(name.Split("_")[1]));
            outline.effectColor = Color.black;
        }

        // 2. 새로운 값 저장
        else if (outline.effectColor == Color.yellow)
        {
            Text text = transform.GetChild(0).GetComponent<Text>();
            reportSettingScript = other.GetComponent<ReportSettingScript>();
            text.text = reportSettingScript.SelectBlank(Int32.Parse(name.Split("_")[1]));
            outline.effectColor = Color.red;
        }
    }

}
