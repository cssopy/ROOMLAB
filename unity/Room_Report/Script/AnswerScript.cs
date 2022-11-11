using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class AnswerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private ReportSettingScript reportSettingScript;
    private Outline outline;
    private Text text;
    private int expIdx;
    public GameObject other;

    public void Awake()
    {
        reportSettingScript = other.GetComponent<ReportSettingScript>();
        text = transform.GetChild(0).GetComponent<Text>();
        // expIdx = PlayerPrefs.GetInt("expIdx");
        expIdx = 0;
        text.text = reportSettingScript.SetAnswers(expIdx ,Int32.Parse(name.Split("_")[1]));
    }

    public void WhileHover()
    {
        if (reportSettingScript.target != Int32.Parse(name.Split("_")[1]))
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.yellow;
        }
    }

    public void WhenLeave()
    {
        if (reportSettingScript.target != Int32.Parse(name.Split("_")[1]))
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.white;
        }
    }

    public void WhenSelected()
    {
        outline = GetComponent<Outline>();
        outline.effectColor = Color.blue;
        reportSettingScript.SelectAnswer(Int32.Parse(name.Split("_")[1]));
    }
}
