using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Reagent : MonoBehaviour
{
    public Transform VialLid;
    public Transform VialLidPivot;

    public Grabbable ThisGrabbable;
    public Grabbable VialLidGrabbable;

    bool IsVialLidGrabed = false;

    void Update()
    {
        if(!IsVialLidGrabed)
        {
            //�Ѳ��� �����ְ� �����ټ� �ֵ��� �ϴ� �ڵ�
            VialLid.position = VialLidPivot.position;
            VialLid.rotation = VialLidPivot.rotation;

            // ���� ����� �� �Ѳ� �Ѳ��� ������ �ְ� Grabbable��ũ��Ʈ�� Ȱ��ȭ
            VialLidGrabbable.enabled = ThisGrabbable.BeingHeld;

            //�Ѳ��� Grabbable��ũ��Ʈ�� �˻��ؼ� �Ѳ��� �������� �˻��� �������� IsVialLidGrabed�� false
            IsVialLidGrabed = VialLidGrabbable.BeingHeld;
        }

    }
}
