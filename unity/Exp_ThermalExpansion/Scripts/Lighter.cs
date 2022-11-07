using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Lighter : GrabbableEvents
{
    private GameObject childObject;
    public bool isActive = false;

    void Start()
    {
        childObject = transform.Find("Flame").gameObject;
    }

    private void Update()
    {
        if (isActive)
        {
            childObject.SetActive(isActive);
        }
        else
        {
            childObject.SetActive(isActive);
        }
    }

    public override void OnTriggerDown()
    {
        isActive = !isActive;
    }

    public void OnActivated()
    {
        isActive = !isActive;
    }
}