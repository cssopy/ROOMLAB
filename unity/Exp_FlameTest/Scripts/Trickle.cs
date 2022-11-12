using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trickle : MonoBehaviour
{
    public Pipette parent;

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Cotton")
        {
            parent.OnParticleCollisionAtTrickle(other);
        }
    }
}
