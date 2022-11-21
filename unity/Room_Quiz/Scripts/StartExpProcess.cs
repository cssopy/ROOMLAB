using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartExpProcess : MonoBehaviour
{
    public GameObject ExpObjectives;
    public GameObject ExpProcess;

    public void nextBtn()
    {
        ExpObjectives.gameObject.SetActive(false);
        ExpProcess.gameObject.SetActive(true);
    }
}
