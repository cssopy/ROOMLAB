using System.Collections;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public string penType;
    private float bottom;


    private void Start()
    {
        bottom = transform.position.y - transform.localScale.y / 2;
    }


    public void StartRipple()
    {
        transform.GetComponentInChildren<MeshRenderer>().material.SetVector("_WaterStartPoint", new Vector3(transform.position.x, bottom, transform.position.z));
        transform.GetComponentInChildren<MeshRenderer>().material.SetFloat("_WaterStartTime", Time.time);
        StartCoroutine(StartColor());
        StartCoroutine(DeleteLine());
    }

    private IEnumerator StartColor()
    {
        yield return new WaitForSeconds(4.0f);
        transform.GetComponentInChildren<MeshRenderer>().material.SetVector("_ColorStartPoint", new Vector3(transform.position.x, bottom + transform.localScale.y / 8, transform.position.z));
        transform.GetComponentInChildren<MeshRenderer>().material.SetFloat("_ColorStartTime", Time.time + 4.0f);
    }
    private IEnumerator DeleteLine()
    {
        yield return new WaitForSeconds(9.0f);
        transform.Find("Lines/Line").gameObject.SetActive(false);
    }

    public void DrawLine()
    {
        if(penType == "RedPen")
        {
            transform.Find("Lines/Line").gameObject.SetActive(true);
            transform.Find("Lines/Line").gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
        }
        else if (penType == "BlackPen")
        {
            transform.Find("Lines/Line").gameObject.SetActive(true);
            transform.Find("Lines/Line").gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
        }

    }

}
