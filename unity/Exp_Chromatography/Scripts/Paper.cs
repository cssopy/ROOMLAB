using System.Collections;
using UnityEngine;

public class Paper : MonoBehaviour
{

    private Material material;
    private float bottom;
    Vector3 WaterStartPoint;
    Vector3 ColorStartPoint;
    [SerializeField]
    GameObject Line;


    void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        bottom = transform.position.y - transform.localScale.y / 2;
        WaterStartPoint = new Vector3(0, bottom, 0);
        ColorStartPoint = new Vector3(0, bottom + transform.localScale.y / 8, 0);
        StartRipple();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastClickBay();
        }
    }

    private void CastClickBay()
    {
        var camera = Camera.main;
        var mousePosition = Input.mousePosition;
        var ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane));
        if(Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            StartRipple();
            Debug.Log("he");
        }
    }

    private void StartRipple()
    {
        material.SetVector("_WaterStartPoint", WaterStartPoint);
        material.SetFloat("_WaterStartTime", Time.time);
        StartCoroutine(StartColor());
        StartCoroutine(DeleteLine());
    }
    IEnumerator StartColor()
    {
        yield return new WaitForSeconds(4.0f);
        material.SetVector("_ColorStartPoint", ColorStartPoint);
        material.SetFloat("_ColorStartTime", Time.time + 4.0f);
    }
    IEnumerator DeleteLine()
    {
        yield return new WaitForSeconds(9.0f);
        Line.SetActive(false);
    }


}
