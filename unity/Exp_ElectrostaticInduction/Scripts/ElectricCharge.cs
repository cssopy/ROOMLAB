using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCharge : MonoBehaviour
{
    int dir;
    float speed;
    float x, y, z;

    public GameObject target = null;

    private void Awake()
    {
        dir = Random.Range(0, 2);
        speed = Random.Range(20f, 60f);
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        z = Random.Range(-1f, 1f);
    }
    void Update()
    {
        if(dir == 0)
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        if(target != null)
        {
            transform.RotateAround(target.transform.position, new Vector3(x,y,z), (speed +20) * Time.deltaTime);
        }
    }
}
