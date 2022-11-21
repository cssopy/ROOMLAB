using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public enum Cut_State
{
    Raycast_Cut,
    Saver_Cut
}
public class RaycasterMovement : MonoBehaviour
{
    [SerializeField] private Transform saver;
    [SerializeField] Cut_State State;


    [SerializeField] GameObject SaverObj, CubeObjs;

    GameObject hitObj;

    private Vector3 _triggerEnterTipPosition;
    private Vector3 _triggerEnterBasePosition;
    private Vector3 _ExitTipPosition;

    private bool GethitObj = false;
    private void Start()
    {
        if (State == Cut_State.Saver_Cut)
        {
            SaverObj.SetActive(true);
            GetComponent<CubeSpawn>().enabled = true;
            StartCoroutine(saverCoroutine());
        }
        else if(State == Cut_State.Raycast_Cut)
        {
            CubeObjs.SetActive(true);
        }
    }
    private void Update()
    {
        if (State == Cut_State.Saver_Cut)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mPosition = Input.mousePosition;
                Vector3 oPosition = saver.transform.position;

                mPosition.z = oPosition.z - Camera.main.transform.position.z;

                Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
                saver.transform.position = target;
            }
        }
        else if (State == Cut_State.Raycast_Cut)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.tag == "Hit")
                    {
                        GethitObj = true;
                        hitObj = hit.transform.gameObject;
                        _triggerEnterTipPosition = hit.point;
                        _triggerEnterBasePosition = new Vector3(hit.point.x, hit.point.y, hit.point.z - 1.0f);
                    }
                }
            }
            if (Input.GetMouseButton(0) && GethitObj)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.tag != "Hit")
                    {
                        GethitObj = false;
                        Cut(hit.point, hitObj);
                    }
                }
            }
        }

    }

    private void Cut(Vector3 ExitTipPosition, GameObject CutObj)
    {
        _ExitTipPosition = ExitTipPosition;

        Vector3 side1 = _triggerEnterTipPosition - _ExitTipPosition;
        Vector3 side2 = _triggerEnterBasePosition - _ExitTipPosition;

        Vector3 normal = Vector3.Cross(side1, side2).normalized;

        Vector3 transformfedNormal = ((Vector3)(CutObj.transform.localToWorldMatrix.transpose * normal)).normalized;

        Vector3 transformedStartingPoint = CutObj.transform.InverseTransformPoint(_triggerEnterTipPosition);

        Plane plane = new Plane();

        plane.SetNormalAndPosition(
            transformfedNormal,
            transformedStartingPoint);

        var direction = Vector3.Dot(Vector3.up, transformfedNormal);

        if(direction <0)
        {
            plane = plane.flipped;
        }

        GameObject[] slices = Slicer.Slice(plane, CutObj);
        Destroy(CutObj);

        Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
        Vector3 newNormal = transformfedNormal + Vector3.up * 5.0f;
        rigidbody.AddForce(newNormal, ForceMode.Impulse);
    }


    IEnumerator saverCoroutine()
    {
        float current = 0;
        float percent = 0;
        Vector3 eulerStart = saver.transform.eulerAngles;
        Vector3 eulerEnd = new Vector3(Random.Range(0, 90.0f), Random.Range(-180.0f, 180.0f), 0.0f);
        while(percent <1)
        {
            current += Time.deltaTime;
            percent = current / 0.3f;
            saver.transform.eulerAngles = Vector3.Lerp(eulerStart, eulerEnd, percent);
            yield return null;
        }
        StartCoroutine(saverCoroutine());
    }
}
