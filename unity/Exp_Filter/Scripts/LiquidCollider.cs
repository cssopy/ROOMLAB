using UnityEngine;

public class LiquidCollider : MonoBehaviour
{

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "Filter")
        {
            other.GetComponent<Filter>().IncreaseHeight();
        } else if (other.name == "LiquidCollider")
        {
            other.transform.parent.GetComponent<BeakerOnStand>().IncreaseHeight();
        }
    }
}
