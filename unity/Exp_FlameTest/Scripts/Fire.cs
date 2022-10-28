using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject sparks;
    public GameObject fire;

    private ParticleSystem.MainModule sparksPSMain;
    private ParticleSystem.MainModule firePSMain;

    private void Awake()
    {
        sparksPSMain = sparks.GetComponent<ParticleSystem>().main;
        firePSMain = fire.GetComponent<ParticleSystem>().main;
    }

    public void setFireColor(Color color)
    {
        sparksPSMain.startColor = color;
        firePSMain.startColor = color;
    }
}
