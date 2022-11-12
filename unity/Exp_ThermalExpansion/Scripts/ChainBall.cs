using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBall : MonoBehaviour
{
    public GameObject Fire;
    public SphereCollider sc;

    float expansionDegree = 0.69f;
    Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(expansionDegree >= 0.9f)
        {
            sc.radius = 0.013f;
        }else if(expansionDegree < 0.9f)
        {
            sc.radius = 0.01f;
        }

        if(expansionDegree > 0.69f)
        {
            expansionDegree -= 0.00005f;
            Debug.Log(renderer.material.color);
            renderer.material.color = new Color(expansionDegree, 0.55f, 0.438f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FireCollider" && Fire.activeSelf)
        {
            if(expansionDegree < 1)
            {
                expansionDegree += 0.0003f;
                Debug.Log(expansionDegree);
                renderer.material.color = new Color(expansionDegree, 0.55f, 0.438f);
            }
        }
    }
}
