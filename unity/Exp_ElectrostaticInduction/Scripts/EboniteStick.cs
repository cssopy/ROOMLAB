using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EboniteStick : MonoBehaviour
{
    public float electrification = 0;

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Fur")
        {
            if(electrification < 1)
            {
                electrification += 0.001f;
            }
        }
    }
}
