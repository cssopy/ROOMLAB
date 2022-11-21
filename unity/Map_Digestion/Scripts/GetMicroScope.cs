using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class GetMicroScope : GrabbableEvents
{
    [SerializeField] Canvas cellCanvas;
    [SerializeField] Camera cellCamera;

    public override void OnGrip(float gripValue)
    {
        cellCanvas.gameObject.SetActive(true);
        cellCanvas.worldCamera = cellCamera;
    }
    public override void OnRelease()
    {
        cellCanvas.gameObject.SetActive(false);
    }

    public override void OnButton2Up()
    {
        Debug.Log("Button 2");
        cellCanvas.gameObject.SetActive(false);
    }

    public override void OnButton1Up()
    {
        Debug.Log("Button 2");
        cellCanvas.gameObject.SetActive(false);
    }

    public override void OnTriggerUp()
    {
        Debug.Log("Button 2");
        cellCanvas.gameObject.SetActive(false);
    }
}
