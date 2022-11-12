using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBtnFlame : MonoBehaviour
{
    public Button next;
    public int num;
    public GameObject[] panels;
    public GameObject Scorepage;
    public int cnt;
    public Text Score;

    public void nextBtn()
    {
        if (num == 3)
        {
            cnt = Quiz1Flame.cnt + Quiz2Flame.cnt + Quiz3Flame.cnt + Quiz4Flame.cnt;
            Debug.Log("Á¡¼ö : " + (cnt * 25) + "Á¡");
            panels[num].gameObject.SetActive(false);
            next.gameObject.SetActive(false);
            Score.text = cnt * 25 + "";
            Scorepage.gameObject.SetActive(true);
            
            return;
        }

        panels[num].gameObject.SetActive(false);
        panels[++num].gameObject.SetActive(true);
    }
}
