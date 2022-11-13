using UnityEngine;
using UnityEngine.UI;
using System;



public class AnswerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Outline outline;
    public GameObject other;
    private ReportSettingScript reportSettingScript;

    private void Awake()
    {
        reportSettingScript = other.GetComponent<ReportSettingScript>();
    }


    public void WhileHover()
    {
        if (reportSettingScript.target != Int32.Parse(name.Split("_")[1]) && reportSettingScript.counts <5)
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
        if (reportSettingScript.counts < 5)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.blue;
            reportSettingScript.SelectAnswer(Int32.Parse(name.Split("_")[1]));
        }
    }
}
