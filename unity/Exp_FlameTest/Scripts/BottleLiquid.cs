using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleLiquid : MonoBehaviour
{
    public GameObject parent;

    Renderer liquid;

    private void Awake()
    {
        liquid = GetComponent<Renderer>();

        if(parent.name == "Cu")
        {
            liquid.material.SetColor("_LiquidColor", new Color(113f / 255f, 192f / 255f, 212f / 255f, 255f / 255f));
            liquid.material.SetColor("_SurfaceColor", new Color(113f / 255f, 192f / 255f, 212f / 255f, 255f / 255f));
        }
        else if (parent.name == "Ba")
        {
            liquid.material.SetColor("_LiquidColor", new Color(1f, 1f, 1f, 60f / 255f));
            liquid.material.SetColor("_SurfaceColor", new Color(1f, 1f, 1f, 60f / 255f));
        }
    }
}
