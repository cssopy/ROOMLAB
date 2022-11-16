using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class GoSolarSystem : GrabbableEvents
{
    public GameObject RoomToSolarPage;
    public override void OnGrab(Grabber grabber)
    {
        Debug.Log("±×·¦ Áß");
        RoomToSolarPage.gameObject.SetActive(true);
    }
}
