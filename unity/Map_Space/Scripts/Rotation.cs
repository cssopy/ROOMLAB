using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, -Time.deltaTime * rotateSpeed, 0));
    }
}
