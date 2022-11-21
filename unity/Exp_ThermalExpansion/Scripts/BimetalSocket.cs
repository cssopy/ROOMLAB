using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BimetalSocket : MonoBehaviour
{
    public Circuit circuit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bimetal")
        {
            circuit.isInstalledMetal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Bimetal")
        {
            circuit.isInstalledMetal = false;
        }
    }
}
