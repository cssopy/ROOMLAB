using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPlate : MonoBehaviour
{
    public GameObject target;

    public GameObject foil1;
    public GameObject foil2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EboniteStick")
        {
            EboniteStick otherComp = other.gameObject.GetComponent<EboniteStick>();
            StartCoroutine(widen(otherComp.electrification));
        }
    }

    private IEnumerator widen(float electrification)
    {
        for(int i=0; i<50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            foil1.transform.RotateAround(target.transform.position, Vector3.right, 60 * electrification * 0.02f);
            foil2.transform.RotateAround(target.transform.position, Vector3.left, 60 * electrification * 0.02f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "EboniteStick")
        {
            EboniteStick otherComp = other.gameObject.GetComponent<EboniteStick>();
            StartCoroutine(narrow(otherComp.electrification));
        }
    }

    private IEnumerator narrow(float electrification)
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            foil1.transform.RotateAround(target.transform.position, Vector3.left, 60 * electrification * 0.02f);
            foil2.transform.RotateAround(target.transform.position, Vector3.right, 60 * electrification * 0.02f);
        }
    }
}
