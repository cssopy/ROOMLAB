using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpFilterMoveBtn : MonoBehaviour
{
    public Button next;
    public int num;
    public GameObject Quiz;
    public GameObject[] panels;
    public GameObject Scorepage;
    public int cnt;
    public Text Score;

    public void nextBtn()
    {
        if (num == 3)
        {
            cnt = ExpFilterQuiz1.cnt + ExpFilterQuiz2.cnt + ExpFilterQuiz3.cnt + ExpFilterQuiz4.cnt;
            Debug.Log("Á¡¼ö : " + (cnt * 25) + "Á¡");
            panels[num].gameObject.SetActive(false);
            next.gameObject.SetActive(false);
            Quiz.gameObject.SetActive(false);
            Score.text = cnt * 25 + "";
            Scorepage.gameObject.SetActive(true);
            
            return;
        }

        panels[num].gameObject.SetActive(false);
        panels[++num].gameObject.SetActive(true);
    }
}
