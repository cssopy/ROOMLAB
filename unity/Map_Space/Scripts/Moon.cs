using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public float rotateSpeed = 0.37037f;
    public Vector3 axis = new Vector3(0f, 1f, 0f);
    public Vector3 diff = new Vector3(0f, 0f, 16.499f);
    private float t = 0;

    private void revolution(in Vector3 axis, in Vector3 diff, float speed, ref float t)
    {
        t += speed * Time.deltaTime;

        Vector3 offset = Quaternion.AngleAxis(t, axis) * diff;
        transform.position = transform.parent.Find("Earth").position + offset;
    }

    void Update()
    {
        revolution(axis, diff, rotateSpeed, ref t);  // 공전
        transform.Rotate(new Vector3(0, -Time.deltaTime * -0.37037f, 0));  // 자전
    }
}