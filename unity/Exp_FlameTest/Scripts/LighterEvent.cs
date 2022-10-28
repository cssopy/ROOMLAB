using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterEvent : MonoBehaviour
{
    private GameObject childObject;
    public bool isActive = false;

    void Start()
    {
        childObject = transform.Find("Flame").gameObject;
        childObject.SetActive(isActive);
    }

    public void OnActivated()
    {
        isActive = !isActive;
        childObject.SetActive(isActive);
    }
}