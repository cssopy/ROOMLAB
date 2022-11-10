using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalAnswerScript : MonoBehaviour
{
    // 10개 박스의 값들
    private string[] answers = new string[10];
    // 해당 위치에 있는 답 인덱스
    private int[] numbers = new int[5] { -1, -1, -1, -1, -1 };
    // 10개의 박스의 최초 위치
    public Vector3[] positions = new Vector3[10];
    // 5개의 빈칸의 최초 위치
    private Vector3[] blanks = new Vector3[5];

    // 기타 변수
    private float dist;
    private GameObject obj;
    private GameObject obj2;
    private Vector3 nextPosition;

    public void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            obj = GameObject.Find($"Blank_{i}");
            blanks[i] = obj.transform.position;
        }
    }

    public void SetAnswers(int n, Vector3 position, string text)
    {
        answers[n] = text;
        positions[n] = position;
    }

    public void isNear(int n, Vector3 position)
    {
        nextPosition = positions[n];
        obj = transform.Find($"Answer_{n}").gameObject;
        for (int i = 0; i < 5; i++)
        {
            dist = Vector3.Distance(blanks[i], position);
            if (dist < 20)
            {
                if (numbers[i] > -1)
                {
                    int m = numbers[i];
                    obj2 = transform.Find($"Answer_{m}").gameObject;
                    obj2.transform.position = positions[m];
                }

                nextPosition = blanks[i];
                numbers[i] = n;

            }
            else if (numbers[i] == n)
            {
                numbers[i] = -1;
            }
        }
        obj.transform.position = nextPosition;
    }

}

// renderer.enabled = true; // Enable the renderer, making the GameObject invisible


