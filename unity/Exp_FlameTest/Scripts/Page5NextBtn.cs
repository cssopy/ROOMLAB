using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page5NextBtn : MonoBehaviour
{
    public GameObject ExpProcessUI;
    public GameObject QuizUI;

    public void onBtnClick()
    {
        ExpProcessUI.SetActive(false);
        QuizUI.SetActive(true);
    }
}
