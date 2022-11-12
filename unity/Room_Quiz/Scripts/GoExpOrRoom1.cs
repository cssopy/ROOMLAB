using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoExpOrRoom1 : MonoBehaviour
{
    public GameObject CurPage;
    public GameObject SelectExpPage;
    //public GameObject ExpPage;
    //public GameObject Room;

    public void GoExpBtn()
    {
        CurPage.gameObject.SetActive(false);
        //ExpPage.gameObject.SetActive(false);
        SelectExpPage.gameObject.SetActive(true);
    }

    public void GoRoomBtn()
    {
        CurPage.gameObject.SetActive(false);
        //ExpPage.gameObject.SetActive(false);
        //Room.gameObject.SetActive(true);
    }
}
