using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomToLab : MonoBehaviour
{
    public Button YesButton;
    public Button NoButton;
    public GameObject GoToLabPage;

    public void YesBtn()
    {
        GoToLabPage.gameObject.SetActive(false);
        SceneManager.LoadScene("ElectrostaticInductionScene");
    }

    public void NoBtn()
    {
        GoToLabPage.gameObject.SetActive(false);
    }
}
