using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBtn : MonoBehaviour
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
            cnt = Quiz1.cnt + Quiz2.cnt + Quiz3.cnt + Quiz4.cnt;
            Debug.Log("���� : " + (cnt * 25) + "��");
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
