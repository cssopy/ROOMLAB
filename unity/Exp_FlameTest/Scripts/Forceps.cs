using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Forceps : GrabbableEvents
{
    public GameObject[] forceps;

    public GameObject target;
    public GameObject socket;
    public GameObject originParent;

    public override void OnTriggerDown()
    {
        forceps[0].transform.Rotate(new Vector3(4, 0, 0));
        forceps[1].transform.Rotate(new Vector3(4, 0, 0));

        if(target != null)
        {
            target.GetComponent<Rigidbody>().isKinematic = true;
            target.transform.parent = socket.transform;

        }
    }

    public override void OnTriggerUp()
    {
        forceps[0].transform.Rotate(new Vector3(-4, 0, 0));
        forceps[1].transform.Rotate(new Vector3(-4, 0, 0));

        if(target != null)
        {
            target.GetComponent<Rigidbody>().isKinematic = false;
            target.transform.parent = originParent.transform;
            StartCoroutine(triggerUpCotton());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cotton" && target == null)
        {
            target = other.gameObject;
        }
    }

    IEnumerator triggerUpCotton()
    {
        yield return new WaitForSeconds(0.5f);
        target = null;
    }
}
