using UnityEngine;
using BNG;

public class Pen : GrabbableEvents
{
    [SerializeField]
    GameObject Paper1;
    [SerializeField]
    GameObject Paper2;

    public bool isActive;

    public override void OnGrip(float gripValue)
    {
        transform.rotation = Quaternion.Euler(-30, 90, 0);
    }

    public override void OnRelease()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public override void OnTriggerDown()
    {
        Paper1.GetComponent<Paper>().DrawLine();
        Paper2.GetComponent<Paper>().DrawLine();
    }

}
