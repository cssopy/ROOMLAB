using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerOnStand : MonoBehaviour
{
    private Renderer liquidRenderer;
    private void Start()
    {
        liquidRenderer = transform.Find("Liquid").gameObject.GetComponent<Renderer>();
    }

    private float GetCurrentHeight()
    {
        return liquidRenderer.material.GetFloat("_Fill");
    }
    private void SetCurrentHeight(float Height)
    {
        liquidRenderer.material.SetFloat("_Fill", Height);
    }
    public void IncreaseHeight()
    {
        SetCurrentHeight(GetCurrentHeight() + 0.00005f);
    }
}
