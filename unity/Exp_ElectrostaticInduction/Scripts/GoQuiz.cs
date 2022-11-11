using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoQuiz : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Button goQuiz;

    public void GoQuizBtn()
    {
        gameObjects[0].gameObject.SetActive(false);
        gameObjects[1].gameObject.SetActive(true);
    }
}
