using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnExpSelect : MonoBehaviour
{
    public GameObject SelectExpPage;
    public GameObject ExpSelect;

    public void returnBtn()
    {
        SelectExpPage.gameObject.SetActive(false);
        ExpSelect.gameObject.SetActive(true);
    }
}
