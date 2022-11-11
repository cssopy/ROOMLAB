using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    Renderer rend;
    [SerializeField]
    ParticleSystem water;
    private float newTheta;
    public float spillPoint;        //  ��Ŀ�� �������� ��, ��ü�� ������ ���ɼ��� �ִ� �ּ����� ����
    public float spillSpeed = 0f;
    private float height;           // ���� ��ü�� ����


    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {   
        height = rend.material.GetFloat("_Fill");
        newTheta = Quaternion.Angle(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)));
        rend.material.SetFloat("_Theta", newTheta);
        spillPoint = Mathf.Cos(newTheta / 180 * Mathf.PI);

        if (height > spillPoint) {
            rend.material.SetFloat("_Fill", height - newTheta * 0.000015f);
            water.Play();
        } else
        {
            water.Stop();
        }

    }
}
