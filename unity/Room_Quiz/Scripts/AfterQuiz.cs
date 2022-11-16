using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterQuiz : MonoBehaviour
{
    public GameObject ScorePage;
    public GameObject AfterQuizPage;

    public void NextBtn()
    {
        ScorePage.gameObject.SetActive(false);
        AfterQuizPage.gameObject.SetActive(true);
    }
}
