using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbSocket : MonoBehaviour
{
    public Circuit circuit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LightBulb")
        {
            circuit.isInstalledLightBulb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "LightBulb")
        {
            circuit.isInstalledLightBulb = false;
        }
    }
}
