using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Paper1" || other.gameObject.name == "Paper2")
        {
            GameObject paper = other.gameObject;
            paper.GetComponent<Paper>().StartRipple();
        }
    }
}
