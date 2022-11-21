using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConceptNextBtn : MonoBehaviour
{
    public Button next;
    public int num;
    public GameObject[] ConceptPage;
    public GameObject ConceptPanel;
    public GameObject ExpObjectives;

    public void nextBtn()
    {
        if (num == 3)
        {
            ConceptPage[num].gameObject.SetActive(false);
            next.gameObject.SetActive(false);
            ConceptPanel.gameObject.SetActive(false);
            ExpObjectives.gameObject.SetActive(true);

            return;
        }

        ConceptPage[num].gameObject.SetActive(false);
        ConceptPage[++num].gameObject.SetActive(true);
    }
}
