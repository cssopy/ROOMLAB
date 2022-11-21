using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject pivot;
    public Vector3 axis;
    public Vector3 diff;
    private float t = 0;

    private void revolution(in Vector3 axis, in Vector3 diff, float speed, ref float t)
    {
        t += speed * Time.deltaTime;

        Vector3 offset = Quaternion.AngleAxis(t, axis) * diff;
        transform.position = pivot.transform.position + offset;
    }

    void Update()
    {
        revolution(axis, diff, rotateSpeed, ref t);  // °øÀü
    }
}
