using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    public bool isInstalledMetal = false;
    public bool isInstalledLightBulb = false;
    public bool isInstalledBattery = false;
    public bool isInContacted = false;

    public GameObject light;
    public GameObject[] electricCharges;

    public GameObject[] contactParts;

    float temp = 0f;
    bool isChange = false;

    private void Update()
    {
        if(isInstalledBattery && isInstalledLightBulb && isInstalledMetal && isInContacted)
        {
            foreach(GameObject electricCharge in electricCharges)
            {
                electricCharge.SetActive(true);
            }
            light.SetActive(true);

            if(temp < 1)
            {
                temp += 0.001f;
            }

            if(temp >= 1 && !isChange)
            {
                isChange = true;
                StartCoroutine(changeBimetal1());
            }
        }
        else
        {
            foreach (GameObject electricCharge in electricCharges)
            {
                electricCharge.SetActive(false);
            }
            light.SetActive(false);

            if (temp > 0)
            {
                temp -= 0.001f;
            }

            if(temp <= 0 && isChange)
            {
                isChange = false;
                StartCoroutine(changeBimetal2());
            }
        }
    }

    IEnumerator changeBimetal1()
    {
        float[] angles = { 0f, 1f, 2f, 3f, 4f, 5f };
        float a = 0f;

        for(int i=0; i<100; i++)
        {
            for(int j=0; j<contactParts.Length; j++)
            {
                contactParts[j].transform.rotation = Quaternion.Euler(angles[j] * a, 0, 0);
            }
            a += 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator changeBimetal2()
    {
        float[] angles = { 0f, 1f, 2f, 3f, 4f, 5f };
        float a = 1f;

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < contactParts.Length; j++)
            {
                contactParts[j].transform.rotation = Quaternion.Euler(angles[j] * a, 0, 0);
            }
            a -= 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
