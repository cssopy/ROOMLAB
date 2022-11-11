using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManage : MonoBehaviour
{
    public int stepOne = 5;

    public CPC_FT cpc_ft;
    public Cotton[] cottons;

    private void Update()
    {
        if(stepOne == 0)
        {
            if (!cpc_ft.isDone[1] && cpc_ft.isOrder(1))
            {
                cpc_ft.SetPage(1);
            }
        }

        if (isDoneStepThree())
        {
            if (!cpc_ft.isDone[3] && cpc_ft.isOrder(3))
            {
                cpc_ft.SetPage(3);
            }
        }

        if (isDoneStepFour())
        {
            if (!cpc_ft.isDone[4] && cpc_ft.isOrder(4))
            {
                cpc_ft.SetPage(4);
            }
        }
    }

    public bool isDoneStepThree()
    {
        foreach (Cotton cotton in cottons)
        {
            if (cotton.type == "")
            {
                return false;
            }
        }

        return true;
    }

    public bool isDoneStepFour()
    {
        foreach (Cotton cotton in cottons)
        {
            if (cotton.isBurned == false)
            {
                return false;
            }
        }

        return true;
    }
}
