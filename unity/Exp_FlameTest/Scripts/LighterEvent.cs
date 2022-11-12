using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class LighterEvent : GrabbableEvents
{
    private GameObject childObject;

    public GameObject button;

    void Start()
    {
        childObject = transform.Find("Flame").gameObject;
    }

    public override void OnTriggerDown()
    {
        childObject.SetActive(true);
        button.transform.Translate(new Vector3(0, 0, 0.005f));
    }

    public override void OnTriggerUp()
    {
        childObject.SetActive(false);
        button.transform.Translate(new Vector3(0, 0, -0.005f));
    }
}