using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySocket : MonoBehaviour
{
    public Circuit circuit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Battery")
        {
            circuit.isInstalledBattery = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Battery")
        {
            circuit.isInstalledBattery = false;
        }
    }
}
