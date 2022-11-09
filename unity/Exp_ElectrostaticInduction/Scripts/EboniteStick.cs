using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EboniteStick : MonoBehaviour
{
    // 전자친화도
    public float electronAffinity = 60f;
    // 띠는 전하
    public string electricCharge = null;
    // 대전값
    public float electrification = 0;
    // 대전도
    public float electrificationDegree = 0;

    // 물체의 전하들
    public GameObject[] electricCharges;
    // 전하들의 materials
    public Material[] materials;

    // 타이머 관련
    public GameObject timerUI;
    public TextMeshProUGUI textMesh;
    public CPC_EI canvasPageCTR;
    float time;

    // 타이머에서의 제한시간 관련
    public GameObject timerOfTU;
    float timeOfTU;

    private void Update()
    {
        if(electricCharge == "plus")
        {
            foreach (GameObject each in electricCharges)
            {
                each.SetActive(true);
                each.GetComponent<MeshRenderer>().material = materials[0];
            }
        }
        else if(electricCharge == "minus")
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

        if (timerUI.activeSelf)
        {
            timeOfTU += Time.deltaTime;

            if(10 - timeOfTU < 0)
            {
                timerUI.SetActive(false);
                timeOfTU = 0f;
            }

            timerOfTU.transform.localScale = new Vector3(0f, 0.001f, (10- timeOfTU)/100);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.name == "FurBundle")
        {
            electricCharge = "minus";
            electrification = Math.Abs(electronAffinity - collision.collider.gameObject.GetComponent<FurBundle>().electronAffinity);

            if (electrificationDegree < 1)
            {
                electrificationDegree += 0.001f;
            }

            runTimer(5);
        }
        else if (collision.collider.gameObject.name == "SilkBundle")
        {
            electricCharge = "minus";
            electrification = Math.Abs(electronAffinity - collision.collider.gameObject.GetComponent<SilkBundle>().electronAffinity);

            if (electrificationDegree < 1)
            {
                electrificationDegree += 0.001f;
            }

            runTimer(3);
        }
        else if (collision.collider.gameObject.name == "Rubber")
        {
            electricCharge = "minus";
            electrification = Math.Abs(electronAffinity - collision.collider.gameObject.GetComponent<Rubber>().electronAffinity);

            if (electrificationDegree < 1)
            {
                electrificationDegree += 0.001f;
            }

            runTimer(1);
        }
        else if (collision.collider.gameObject.name == "Insulator")
        {
            initEboniteStick();
        }
    }

    private void initEboniteStick()
    {
        electronAffinity = 60f;
        electricCharge = null;
        electrification = 0;
        electrificationDegree = 0;
    }

    public void runTimer(int num)
    {
        if (!canvasPageCTR.isDone[num] && canvasPageCTR.isOrder(num))
        {
            if (!timerUI.activeSelf)
            {
                timerUI.SetActive(true);
            }

            time += Time.deltaTime;
            textMesh.text = string.Format("{0:N2}초", time);

            if (time >= 5)
            {
                canvasPageCTR.SetPage(num);
                time = 0;
                timerUI.SetActive(false);
            }
        }
    }
}
