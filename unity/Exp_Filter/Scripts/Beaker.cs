using UnityEngine;
using BNG;

public class Beaker : GrabbableEvents
{
    [SerializeField]
    GameObject canvas;
    public override void OnGrip(float gripValue)
    {
        canvas.GetComponent<CheckForCanvas>().isBeakerOnHand = true;
    }
    public override void OnRelease()
    {
        canvas.GetComponent<CheckForCanvas>().isBeakerOnHand = false;
    }
}
