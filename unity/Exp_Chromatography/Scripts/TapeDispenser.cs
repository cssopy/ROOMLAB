using BNG;
using UnityEngine;

public class TapeDispenser : GrabbableEvents
{
    [SerializeField]
    GameObject Tape1;
    [SerializeField]
    GameObject Tape2;

    // When grab tape, the hand will rotate
    public override void OnGrip(float gripValue)
    {
        if (!Tape1.GetComponent<Tape>().isAttached && !Tape1.GetComponent<Tape>().isGripped)
            Tape1.transform.position = transform.position + new Vector3(0, 0, 0.1f);
        if (!Tape2.GetComponent<Tape>().isAttached && !Tape2.GetComponent<Tape>().isGripped)
            Tape2.transform.position = transform.position + new Vector3(0, 0, 0.1f);
    }



    public override void OnTriggerDown()
    {

    }
}
