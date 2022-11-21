using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class OpenReport : GrabbableEvents
{
    public GameObject ReportMonitor;

    public override void OnGrab(Grabber grabber)
    {
        Debug.Log("±×·¦ Áß");
        ReportMonitor.gameObject.SetActive(true);
    }
}
