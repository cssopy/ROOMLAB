using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    public bool isInstalledMetal = false;
    public bool isInstalledLightBulb = false;
    public bool isInstalledBattery = false;
    public bool isInContacted = false;

    public GameObject light;

    private void Update()
    {
        if(isInstalledBattery && isInstalledLightBulb && isInstalledMetal && isInContacted)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }
    }
}
