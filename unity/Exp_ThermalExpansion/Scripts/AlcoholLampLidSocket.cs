using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholLampLidSocket : MonoBehaviour
{
    public GameObject fire;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "AlcoholLampLid")
        {
            fire.SetActive(false);
        }
    }
}
