using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class GoLab : GrabbableEvents
{
    public GameObject RoomToLabPage;
    public override void OnGrab(Grabber grabber)
    {
        Debug.Log("�׷� ��");
        RoomToLabPage.gameObject.SetActive(true);
    }
}
