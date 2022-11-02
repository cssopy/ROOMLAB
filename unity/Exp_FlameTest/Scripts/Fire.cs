using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject sparks;
    public GameObject fire;

    private ParticleSystem thisPS;
    private ParticleSystem sparksPS;
    private ParticleSystem firePS;

    private void Awake()
    {
        thisPS = GetComponent<ParticleSystem>();
        sparksPS = sparks.GetComponent<ParticleSystem>();
        firePS = fire.GetComponent<ParticleSystem>();
    }

    public void setFireColor(Color color)
    {
        var main = thisPS.main;
        main.startColor = color;
        main = sparksPS.main;
        main.startColor = color;
        main = firePS.main;
        main.startColor = color;
    }
}
