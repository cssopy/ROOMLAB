using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoExpOrRoom2 : MonoBehaviour
{
    public GameObject ExpSelect;
    public GameObject SelectExpPage;
    
    public void GoExpSelect()
    {
        ExpSelect.gameObject.SetActive(false);
        SelectExpPage.gameObject.SetActive(true);
    }

    public void GoRoom()
    {
        SceneManager.LoadScene("children_room");
    }
}
