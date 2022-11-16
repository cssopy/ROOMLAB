using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomToSpace : MonoBehaviour
{
    public Button YesButton;
    public Button NoButton;
    public GameObject GoToSpacePage;

    public void YesBtn()
    {
        GoToSpacePage.gameObject.SetActive(false);
        SceneManager.LoadScene("SolarMainScene");
    }

    public void noBtn()
    {
        GoToSpacePage.gameObject.SetActive(false);
    }
}
