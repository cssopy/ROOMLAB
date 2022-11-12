using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker_TE : MonoBehaviour
{
    public GameObject smoke;
    public ChainBall ChainBall;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ChainBall" && ChainBall.expansionDegree > 0.7)
        {
            smoke.SetActive(true);
            ChainBall.init();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ChainBall")
        {
            smoke.SetActive(false);
        }
    }
}
