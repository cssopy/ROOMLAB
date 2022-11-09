using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPC_FT : MonoBehaviour
{
    public GameObject[] GameObjects;

    public bool[] isDone = { true, false, false, false, false };

    public void SetPage(int num)
    {
        if (num < 0 || num > 4)
        {
            return;
        }

        if (!isDone[num])
        {
            for (int i = 0; i < GameObjects.Length; i++)
                GameObjects[i].SetActive(false);
            GameObjects[num].SetActive(true);
            isDone[num] = true;
        }
    }

    public bool isOrder(int num)
    {
        for(int i=0; i<num; i++)
        {
            if (!isDone[i])
            {
                return false;
            }
        }
        return true;
    }
}