using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grain : MonoBehaviour
{
    float R = 127f;
    float G = 127f;
    float B = 127f;

    float ColorCurve;

    private new Renderer renderer;

    private void Awake()
    {
        renderer = this.GetComponent<Renderer>();
        ColorCurve = Random.Range(-0.2f, -0.1f);
    }

    public void onFile()
    {
        R += ColorCurve;
        G += ColorCurve;
        B += ColorCurve;

        renderer.material.color = new Color(R/255f, G/255f, B/255f);
    }
}
