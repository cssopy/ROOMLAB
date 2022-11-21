using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public ExpManage expManage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cotton")
        {
            expManage.stepOne--;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Cotton")
        {
            expManage.stepOne++;
        }
    }
}
