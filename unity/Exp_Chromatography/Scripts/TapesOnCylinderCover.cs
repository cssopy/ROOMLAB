using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapesOnCylinderCover : MonoBehaviour
{
    [SerializeField]
    GameObject paper1;
    [SerializeField]
    GameObject paper2;
    bool isAttached;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isAttached)
        {
            GameObject tapeOnCylinderCover = transform.GetChild(0).gameObject;
            if (other.gameObject.name == "SmallTapeforPaper1")
            {
                isAttached = true;
                tapeOnCylinderCover.SetActive(true);
                paper1.GetComponent<HingeJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
                paper1.GetComponent<HingeJoint>().connectedAnchor = new Vector3(0.001f, 0.5f, 0);
                other.gameObject.SetActive(false);
            } else if (other.gameObject.name == "SmallTapeforPaper2") {
                isAttached = true;
                tapeOnCylinderCover.SetActive(true);
                paper2.GetComponent<HingeJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
                paper2.GetComponent<HingeJoint>().connectedAnchor = new Vector3(0.001f, 0.5f, 0);
                other.gameObject.SetActive(false);
            }
        }
    }
}
