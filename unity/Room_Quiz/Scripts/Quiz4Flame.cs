using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz4Flame : MonoBehaviour
{
    public Button O;
    public Button X;
    public Text right;
    public Text wrong;
    public static int cnt;
    public static bool cked;

    public void OBtn()
    {
        if (cked)
        {
            return;
        }
        right.gameObject.SetActive(false);
        O.gameObject.SetActive(false);
        X.gameObject.SetActive(false);
        wrong.gameObject.SetActive(true);
        cked = true;
    }

    public void XBtn()
    {
        if (cked)
        {
            return;
        }
        wrong.gameObject.SetActive(false);
        O.gameObject.SetActive(false);
        X.gameObject.SetActive(false);
        right.gameObject.SetActive(true);
        cnt += 1;
        cked = true;
    }
}
