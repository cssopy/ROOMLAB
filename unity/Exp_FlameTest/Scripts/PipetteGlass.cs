using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipetteGlass : MonoBehaviour
{
    public Pipette parent;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sample")
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                parent.OnTriggerEnterInGlass(other);
            }
        }
    }
}
