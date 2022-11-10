using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCharge_TE : MonoBehaviour
{
    int dir;
    float speed;

    public GameObject start = null;
    public GameObject target = null;

    private void Awake()
    {
        dir = Random.Range(0, 2);
        speed = Random.Range(20f, 60f);
    }
    void Update()
    {
        if (dir == 0)
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 0.001f);

        if(transform.position == target.transform.position)
        {
            transform.position = start.transform.position;
        }
    }
}
