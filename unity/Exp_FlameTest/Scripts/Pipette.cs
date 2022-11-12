using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Pipette : GrabbableEvents
{
    public GameObject glassLiquid;
    public GameObject trickle;
    public string sampleName = null;

    public CPC_FT cpc_ft;

    private Renderer glassLiquidRenderer;
    private bool isInteractingWithSample = false;

    Collider other = null;

    private void Awake()
    {
        glassLiquidRenderer = glassLiquid.GetComponent<Renderer>();
    }

    public override void OnTriggerDown()
    {
        if (!isInteractingWithSample)
        {
            float colour = glassLiquidRenderer.material.GetFloat("_Fill");
            if (colour > -1)
            {
                if (!cpc_ft.isDone[2] && cpc_ft.isOrder(2))
                {
                    cpc_ft.SetPage(2);
                }

                colour += -0.005f;
                glassLiquidRenderer.material.SetFloat("_Fill", colour);
                StartCoroutine(playTrickle());
            }
            else
            {
                sampleName = null;
            }
        }else if (isInteractingWithSample && other != null)
        {
            sampleName = other.name;
            if (other.name == "Cu")
            {
                glassLiquidRenderer.material.SetColor("_LiquidColor", new Color(113f / 255f, 192f / 255f, 212f / 255f));
                glassLiquidRenderer.material.SetColor("_SurfaceColor", new Color(113f / 255f, 192f / 255f, 212f / 255f));
            }
            else if (other.name == "Ba")
            {
                glassLiquidRenderer.material.SetColor("_LiquidColor", new Color(1f, 1f, 1f));
                glassLiquidRenderer.material.SetColor("_SurfaceColor", new Color(1f, 1f, 1f));
            }
            else
            {
                glassLiquidRenderer.material.SetColor("_LiquidColor", new Color(193f/255f, 198f/255f, 200f/ 255f));
                glassLiquidRenderer.material.SetColor("_SurfaceColor", new Color(193f / 255f, 198f / 255f, 200f / 255f));
            }

            float colour = glassLiquidRenderer.material.GetFloat("_Fill");
            if (colour < 0.55)
            {
                colour += 0.005f;
                glassLiquidRenderer.material.SetFloat("_Fill", colour);
            }
        }
    }

    private IEnumerator playTrickle()
    {
        trickle.SetActive(true);
        yield return new WaitForSeconds(1f);
        trickle.SetActive(false);
    }

    public void OnTriggerEnterInGlass(Collider other)
    {
        isInteractingWithSample = true;
        this.other = other;
    }

    public void OnTriggerExitInGlass()
    {
        isInteractingWithSample = false;
        this.other = null;
    }

    public void OnParticleCollisionAtTrickle(GameObject other)
    {
        other.GetComponent<Cotton>().type = sampleName;
    }
}
