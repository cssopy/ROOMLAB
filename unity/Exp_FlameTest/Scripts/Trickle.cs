using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trickle : MonoBehaviour
{
    public Pipette parent;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("뭔가 인식" + other.name + other.tag);
        if(other.tag == "Cotton")
        {
            Debug.Log("인식");
            parent.OnParticleCollisionAtTrickle(other);
        }
    }
}
