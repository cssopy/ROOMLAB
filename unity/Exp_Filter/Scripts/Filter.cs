using UnityEngine;
using System;

public class Filter : MonoBehaviour
{
    private Renderer liquidRenderer;
    private Renderer wetFilterRenderer;
    private ParticleSystem drop;
    private float maxHeight = -0.021f;
    private ParticleSystem naphthalene;
    public bool filterTriggered = false;
    [SerializeField]
    private GameObject pincette1;
    [SerializeField]
    private GameObject pincette2;
    Transform filterUnfolded;

    private void Start()
    {
        //wetFilterRenderer = transform.Find("WetFilter").gameObject.GetComponent<Renderer>();
        liquidRenderer = transform.Find("Liquid").gameObject.GetComponent<Renderer>();
        drop = transform.Find("Drop").GetComponent<ParticleSystem>();
        naphthalene = transform.Find("Naphthalene").gameObject.GetComponent<ParticleSystem>();
        filterUnfolded = transform.parent.Find("FilterUnfolded");
    }

    public void IncreaseHeight()
    {
        SetCurrentHeight(GetCurrentHeight() + 0.001f);
        maxHeight = Math.Max(maxHeight, GetCurrentHeight() * 0.021f); 
    }

    private float GetCurrentHeight()
    {
        return liquidRenderer.material.GetFloat("_Fill");
    }
    private void SetCurrentHeight(float Height)
    {
        liquidRenderer.material.SetFloat("_Fill", Height);
    }

    private void SetWetFilterHeight(float Height)
    {
        wetFilterRenderer.material.SetFloat("_Height", Height);
    }
    private void Update()
    {
        if (GetCurrentHeight() > -1f)
        {
            //SetWetFilterHeight(maxHeight);
            SetCurrentHeight(GetCurrentHeight() - 0.001f);
            drop.Play();
            naphthalene.Play();
        } else
        {
            drop.Stop();
            naphthalene.Pause();
        }
        if (filterTriggered)
        {
            transform.parent.position = (pincette1.transform.position + pincette2.transform.position - new Vector3(0, 0.185f, 0)) / 2;
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().isKinematic = true;
        } else
        {
            if (GetComponent<Rigidbody>() != null)
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "GlassPlate")
        {

            filterUnfolded.gameObject.SetActive(true);
            transform.Find("Naphthalene").parent = filterUnfolded;
        }
    }


}
