using UnityEngine;
using BNG;

public class GlassStick : GrabbableEvents
{
    [SerializeField]
    private GameObject canvas;
    public override void OnGrip(float gripValue)
    {
        canvas.GetComponent<CheckForCanvas>().isGlassStickOnHand = true;
    }
    public override void OnRelease()
    {
        canvas.GetComponent<CheckForCanvas>().isGlassStickOnHand = false;
    }
}
