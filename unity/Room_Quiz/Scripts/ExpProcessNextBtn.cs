using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpProcessNextBtn : MonoBehaviour
{
    public GameObject ExpProcessPanel;
    public GameObject FinishExpPanel;

    public void nextBtn()
    {
        ExpProcessPanel.gameObject.SetActive(false);
        FinishExpPanel.gameObject.SetActive(true);
    }
}
