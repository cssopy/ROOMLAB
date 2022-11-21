using UnityEngine;
using UnityEngine.UI;
using System;

public class ViewPictureScript : MonoBehaviour
{
    private Outline outline;
    private AllReportViewScript allReportViewScript;
    public GameObject other;

    private void Awake()
    {
        allReportViewScript = other.GetComponent<AllReportViewScript>();
    }

    public void WhileHover()
    {
        allReportViewScript.TogglePreview(Int32.Parse(name.Split("_")[1]));
        outline = GetComponent<Outline>();
        outline.effectColor = Color.yellow;
        
    }

    public void WhenLeave()
    {
        allReportViewScript.TogglePreview(-1);
        outline = GetComponent<Outline>();
        outline.effectColor = Color.black;
    }
}
