using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterTrigger : MonoBehaviour
{
    public bool pincetteEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PincetteTriggerPoint")
        {   
            pincetteEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PincetteTriggerPoint")
        {
            pincetteEntered = false;
        }
    }
}
