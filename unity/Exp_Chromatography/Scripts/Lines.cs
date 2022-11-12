using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RedPen" || other.gameObject.name == "BlackPen")
        {
            transform.parent.gameObject.GetComponent<Paper>().penType = other.gameObject.name;
        }
    }

    private void OnTriggerExit()
    {
        transform.parent.gameObject.GetComponent<Paper>().penType = "";
    }
}
