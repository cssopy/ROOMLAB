using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBall : MonoBehaviour
{
    public GameObject Fire;
    public SphereCollider sc;

    float expansionDegree = 0.225f;
    Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(expansionDegree >= 0.35)
        {
            sc.radius = 0.013f;
        }else if(expansionDegree < 0.35)
        {
            sc.radius = 0.01f;
        }

        if(expansionDegree > 0.225)
        {
            expansionDegree -= 0.00003f;
            renderer.material.color = new Color(expansionDegree, 0.225f, 0.225f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FireCollider" && Fire.activeSelf)
        {
            if(expansionDegree < 1)
            {
                expansionDegree += 0.0001f;
                renderer.material.color = new Color(expansionDegree, 0.225f, 0.225f);
            }
        }
    }
}
