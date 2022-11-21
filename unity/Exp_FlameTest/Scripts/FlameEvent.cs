using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bowl")
        {
            other.transform.Find("Fire").gameObject.SetActive(true);
        }
    }
}
