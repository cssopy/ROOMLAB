using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPart : MonoBehaviour
{
    public Circuit circuit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ContactPart")
        {
            circuit.isInContacted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ContactPart")
        {
            circuit.isInContacted = false;
        }
    }
}
