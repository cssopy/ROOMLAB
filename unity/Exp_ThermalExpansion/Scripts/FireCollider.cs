using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public GameObject Fire;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flame")
        {
            Fire.SetActive(true);
        }
    }
}
