using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoExpOrRoom1 : MonoBehaviour
{
    public GameObject CurPage;
    public GameObject SelectExpPage;
    public GameObject QuizPanel;
    //public GameObject ExpPage;
    //public GameObject Room;

    public void GoExpBtn()
    {
        CurPage.gameObject.SetActive(false);
        QuizPanel.gameObject.SetActive(false);
        //ExpPage.gameObject.SetActive(false);
        SelectExpPage.gameObject.SetActive(true);
    }

    public void GoRoomBtn()
    {
        CurPage.gameObject.SetActive(false);
        QuizPanel.gameObject.SetActive(false);

        SceneManager.LoadScene("children_room");
        //ExpPage.gameObject.SetActive(false);
        //Room.gameObject.SetActive(true);
    }
}
