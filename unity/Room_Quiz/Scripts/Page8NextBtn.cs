using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page8NextBtn : MonoBehaviour
{
    public GameObject quizPanel;
    public GameObject ExpProcessUI;
    public GameObject QuizUI;

    public void onBtnClick()
    {
        ExpProcessUI.SetActive(false);
        quizPanel.SetActive(true);
        QuizUI.SetActive(true);
    }
}
