using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FurBundle : MonoBehaviour
{
    // 전자친화도
    public float electronAffinity = 0;
    // 띠는 전하
    public string electricCharge = null;
    // 대전값
    public float electrification = 0;
    // 대전도
    public float electrificationDegree = 0;

    public GameObject[] electricCharges;
    public Material[] materials;

    private void Update()
    {
        if (electricCharge == "plus")
        {
            foreach (GameObject each in electricCharges)
            {
                each.SetActive(true);
                each.GetComponent<MeshRenderer>().material = materials[0];
            }
        }
        else if (electricCharge == "minus")
        {
            foreach (GameObject each in electricCharges)
            {
                each.SetActive(true);
                each.GetComponent<MeshRenderer>().material = materials[1];
            }
        }
        else
        {
            foreach (GameObject each in electricCharges)
            {
                each.SetActive(false);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.name == "SilkBundle")
        {
            electricCharge = "plus";
            electrification = Math.Abs(electronAffinity - collision.collider.gameObject.GetComponent<SilkBundle>().electronAffinity);

            if (electrificationDegree < 1)
            {
                electrificationDegree += 0.001f;
            }
        }else if (collision.collider.gameObject.name == "Rubber")
        {
            electricCharge = "plus";
            electrification = Math.Abs(electronAffinity - collision.collider.gameObject.GetComponent<Rubber>().electronAffinity);

            if (electrificationDegree < 1)
            {
                electrificationDegree += 0.001f;
            }
        }
        else if (collision.collider.gameObject.name == "EboniteStick")
        {
            electricCharge = "plus";
            electrification = Math.Abs(electronAffinity - collision.collider.gameObject.GetComponent<EboniteStick>().electronAffinity);

            if (electrificationDegree < 1)
            {
                electrificationDegree += 0.001f;
            }
        }
    }
}
