using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipetteGlass : MonoBehaviour
{
    public Pipette parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sample")
        {
            parent.OnTriggerEnterInGlass();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sample")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                parent.OnTriggerStayInGlass(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sample")
        {
            parent.OnTriggerExitInGlass();
        }
    }
}
