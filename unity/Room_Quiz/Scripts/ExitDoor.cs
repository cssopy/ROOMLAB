using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject doorClick;
    public GameObject askPage;

    public void OnExitDoorClick()
    {
        Debug.Log("������ �� Ŭ��");
        doorClick.gameObject.SetActive(false);
        askPage.gameObject.SetActive(true);
    }
}
