using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trickle : MonoBehaviour
{
    public Pipette parent;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("���� �ν�" + other.name + other.tag);
        if(other.tag == "Cotton")
        {
            Debug.Log("�ν�");
            parent.OnParticleCollisionAtTrickle(other);
        }
    }
}
