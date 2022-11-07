using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public float rotateSpeed = 0.027397f;
    public Vector3 axis = new Vector3(0f, 1f, 0f);
    public Vector3 diff = new Vector3(0f, 0f, 927.1855f);
    private float t = 0;

    private void revolution(in Vector3 axis, in Vector3 diff, float speed, ref float t)
    {
        t += speed * Time.deltaTime;

        Vector3 offset = Quaternion.AngleAxis(t, axis) * diff;
        transform.position = transform.parent.Find("Sun").position + offset;
    }

    void Update()
    {
        revolution(axis, diff, rotateSpeed, ref t);  // 공전
        transform.Rotate(new Vector3(0, -Time.deltaTime * 10f, 0));  // 자전
    }
}