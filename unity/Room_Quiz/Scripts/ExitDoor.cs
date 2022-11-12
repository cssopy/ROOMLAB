using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject doorClick;
    public GameObject askPage;

    public void OnExitDoorClick()
    {
        Debug.Log("나가는 문 클릭");
        doorClick.gameObject.SetActive(false);
        askPage.gameObject.SetActive(true);
    }
}
