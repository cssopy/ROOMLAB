using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette : MonoBehaviour
{
    public GameObject glassLiquid;
    public GameObject trickle;
    public bool isActiving = false;
    public string sampleName = null;

    private Renderer glassLiquidRenderer;

    private void Start()
    {
        glassLiquidRenderer = glassLiquid.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (isActiving)
        {
            trickle.SetActive(true);
        }
        else
        {
            trickle.SetActive(false);
        }
    }

    public void OnActivated()
    {
        isActiving = !isActiving;
    }

    public void OnTriggerEnterInGlass(Collider other)
    {
        float colour = glassLiquidRenderer.material.GetFloat("Colour") + 0.001f;
        glassLiquidRenderer.material.SetFloat("Colour", colour);
    }
}
