using UnityEngine;
using BNG;

public class GlassStick : GrabbableEvents
{
    public override void OnGrip(float gripValue)
    {
        transform.rotation = Quaternion.Euler(0, -90, -30);
    }

    public override void OnRelease()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
