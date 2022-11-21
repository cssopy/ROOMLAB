using UnityEngine;
using UnityEngine.UI;
using System;

public class ExpDetailScript : MonoBehaviour
{
    public GameObject Controller;
    private ExpListController ExpListController;


    public void Awake()
    {
        ExpListController = Controller.GetComponent<ExpListController>();
    }


    public void WhileHover(int n)
    {
        // 색 변경
        transform.GetComponent<RawImage>().color = Color.grey;

        // 이미지 입히기
        ExpListController.ToggleDetail(n);
    }

    public void WhenLeave(int m)
    {
        // 색 변경
        transform.GetComponent<RawImage>().color = Color.white;

        // 이미지 빼기
        ExpListController.ToggleDetail( -1);

    }
}
