using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPlate : MonoBehaviour
{
    public string topElectricCharge = null;

    public GameObject target;

    public GameObject foil1;
    public GameObject foil2;

    public GameObject[] topElectricCharges;
    public GameObject[] bottomElectricCharges;
    public Material[] materials;

    private void Update()
    {
        if(topElectricCharge == "plus")
        {
            foreach(GameObject gameObject in topElectricCharges)
            {
                gameObject.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().material = materials[0];
            }
            foreach(GameObject gameObject in bottomElectricCharges)
            {
                gameObject.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().material = materials[1];
            }
        }else if(topElectricCharge == "minus")
        {
            foreach (GameObject gameObject in topElectricCharges)
            {
                gameObject.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().material = materials[1];
            }
            foreach (GameObject gameObject in bottomElectricCharges)
            {
                gameObject.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().material = materials[0];
            }
        }
        else
        {
            foreach (GameObject gameObject in topElectricCharges)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in bottomElectricCharges)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EboniteStick")
        {
            EboniteStick otherComp = other.gameObject.GetComponent<EboniteStick>();
            setElectricCharge(otherComp.electricCharge);
            StartCoroutine(widen(otherComp.electrification, otherComp.electrificationDegree));
        }
        else if (other.name == "Rubber")
        {
            Rubber otherComp = other.gameObject.GetComponent<Rubber>();
            setElectricCharge(otherComp.electricCharge);
            StartCoroutine(widen(otherComp.electrification, otherComp.electrificationDegree));
        }
        else if (other.name == "SilkBundle")
        {
            SilkBundle otherComp = other.gameObject.GetComponent<SilkBundle>();
            setElectricCharge(otherComp.electricCharge);
            StartCoroutine(widen(otherComp.electrification, otherComp.electrificationDegree));
        }
        else if (other.name == "FurBundle")
        {
            FurBundle otherComp = other.gameObject.GetComponent<FurBundle>();
            setElectricCharge(otherComp.electricCharge);
            StartCoroutine(widen(otherComp.electrification, otherComp.electrificationDegree));
        }
    }

    private void setElectricCharge(string otherEC)
    {
        if (otherEC == "plus")
        {
            topElectricCharge = "minus";
        }
        else if (otherEC == "minus")
        {
            topElectricCharge = "plus";
        }
    }

    private IEnumerator widen(float electrification, float electrificationDegree)
    {
        for(int i=0; i<50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            foil1.transform.RotateAround(target.transform.position, Vector3.right, electrification * electrificationDegree * 0.02f);
            foil2.transform.RotateAround(target.transform.position, Vector3.left, electrification * electrificationDegree * 0.02f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        topElectricCharge = null;
        if (other.name == "EboniteStick")
        {
            EboniteStick otherComp = other.gameObject.GetComponent<EboniteStick>();
            StartCoroutine(narrow(otherComp.electrification, otherComp.electrificationDegree));
        }
        else if (other.name == "Rubber")
        {
            Rubber otherComp = other.gameObject.GetComponent<Rubber>();
            StartCoroutine(narrow(otherComp.electrification, otherComp.electrificationDegree));
        }
        else if (other.name == "SilkBundle")
        {
            SilkBundle otherComp = other.gameObject.GetComponent<SilkBundle>();
            StartCoroutine(narrow(otherComp.electrification, otherComp.electrificationDegree));
        }
        else if (other.name == "FurBundle")
        {
            FurBundle otherComp = other.gameObject.GetComponent<FurBundle>();
            StartCoroutine(narrow(otherComp.electrification, otherComp.electrificationDegree));
        }
    }

    private IEnumerator narrow(float electrification, float electrificationDegree)
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            foil1.transform.RotateAround(target.transform.position, Vector3.left, electrification * electrificationDegree * 0.02f);
            foil2.transform.RotateAround(target.transform.position, Vector3.right, electrification * electrificationDegree * 0.02f);
        }
    }
}
