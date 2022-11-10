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
        if (reportSettingScript.target == -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.yellow;
        }
    }

    public void WhenLeave()
    {
        reportSettingScript = other.GetComponent<ReportSettingScript>();
        if (reportSettingScript.target == -1)
        {
            outline = GetComponent<Outline>();
            outline.effectColor = Color.black;
        }
    }

    public void WhenClicked()
    {
        reportSettingScript = other.GetComponent<ReportSettingScript>();
        if (reportSettingScript.target == -1)
        {
            reportSettingScript.SetBlank(Int32.Parse(name.Split("_")[1]));
            outline = GetComponent<Outline>();
            outline.effectColor = Color.blue;
        }
    }

}
