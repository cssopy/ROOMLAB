using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoQuizFlame : MonoBehaviour
{
    public GameObject[] gameObjects;

    public UISoundSystem_FT uISoundSystem;

    public void GoQuizBtn()
    {
        uISoundSystem.onUI.Play();

        gameObjects[0].gameObject.SetActive(false);
        gameObjects[1].gameObject.SetActive(true);
    }
}
