using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Pipette : GrabbableEvents
{
    public GameObject glassLiquid;
    public GameObject trickle;
    public string sampleName = null;

    private Renderer glassLiquidRenderer;
    private bool isInteractingWithSample = false;

    private void Awake()
    {
        glassLiquidRenderer = glassLiquid.GetComponent<Renderer>();
    }

    public override void OnTriggerDown()
    {
        if (!isInteractingWithSample)
        {
            float colour = glassLiquidRenderer.material.GetFloat("_FillAmount");
            if (colour < 0.581)
            {
                colour += 0.01f;
                glassLiquidRenderer.material.SetFloat("_FillAmount", colour);
                StartCoroutine(playTrickle());
            }
            else
            {
                sampleName = null;
            }
        }
    }

    /*public void OnActivated()
    {
        if (!isInteractingWithSample)
        {
            float colour = glassLiquidRenderer.material.GetFloat("_FillAmount");
            if (colour < 0.581)
            {
                colour += 0.01f;
                glassLiquidRenderer.material.SetFloat("_FillAmount", colour);
                StartCoroutine(playTrickle());
            }
            else
            {
                sampleName = null;
            }
        }
    }*/

    private IEnumerator playTrickle()
    {
        trickle.SetActive(true);
        yield return new WaitForSeconds(1f);
        trickle.SetActive(false);
    }

    public void OnTriggerEnterInGlass()
    {
        isInteractingWithSample = true;
    }

    public void OnTriggerStayInGlass(Collider other)
    {
        if (isInteractingWithSample)
        {
            sampleName = other.name;
            if(other.name == "Cu")
            {
                glassLiquidRenderer.material.SetColor("_Colour", new Color(118f / 255f, 183f / 255f, 163f / 255f, 255f / 255f));
            }
            else if(other.name == "Ba")
            {
                glassLiquidRenderer.material.SetColor("_Colour", new Color(105f / 255f, 104f / 255f, 125f / 255f, 60f / 255f));
            }
            else
            {
                glassLiquidRenderer.material.SetColor("_Colour", Color.gray);
            }

            float colour = glassLiquidRenderer.material.GetFloat("_FillAmount");
            if (colour > 0.4)
            {
                colour += -0.01f;
                glassLiquidRenderer.material.SetFloat("_FillAmount", colour);
            }
        }
    }

    public void OnTriggerExitInGlass()
    {
        isInteractingWithSample = false;
    }

    public void OnParticleCollisionAtTrickle(GameObject other)
    {
        Debug.Log("부모 함수 진입");
        other.GetComponent<Cotton>().type = sampleName;
    }
}
