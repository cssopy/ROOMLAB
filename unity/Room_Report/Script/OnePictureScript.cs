using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OnePictureScript : MonoBehaviour
{
    private ReportSettingScript reportSettingScript;
    private PictureScript pictureScript;
    private Outline outline;


    public void Awake()
    {
        pictureScript = transform.parent.GetComponent<PictureScript>();
    }



    public void WhileHover()
    {
        pictureScript.OpenPreview(Int32.Parse(name.Split("_")[1]));
        outline = GetComponent<Outline>();
        if(outline.effectColor != Color.magenta)
        {
            outline.effectColor = Color.yellow;
        }
    }

    public void WhenLeave()
    {
        pictureScript.ClosePreview();
        outline = GetComponent<Outline>();
        if (outline.effectColor != Color.magenta)
        {
            outline.effectColor = Color.black;
        }
    }

    public void WhenClicked()
    {
        outline = GetComponent<Outline>();
        if (pictureScript.SelectPicture(Int32.Parse(name.Split("_")[1])))
        {
            outline.effectColor = Color.magenta;
            transform.Find($"Check_mark_{Int32.Parse(name.Split("_")[1])}").gameObject.SetActive(true);
        }
        else
        {
            outline.effectColor = Color.yellow;
            transform.Find($"Check_mark_{Int32.Parse(name.Split("_")[1])}").gameObject.SetActive(false);
        }
    }
}
