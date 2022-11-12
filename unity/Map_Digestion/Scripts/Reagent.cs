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
            //뚜껑이 닫혀있게 보여줄수 있도록 하는 코드
            VialLid.position = VialLidPivot.position;
            VialLid.rotation = VialLidPivot.rotation;

            // 병을 잡았을 때 뚜껑 뚜껑을 잡을수 있게 Grabbable스크립트를 활성화
            VialLidGrabbable.enabled = ThisGrabbable.BeingHeld;

            //뚜껑의 Grabbable스크립트를 검사해서 뚜껑이 잡혔는지 검사후 잡혔으면 IsVialLidGrabed를 false
            IsVialLidGrabed = VialLidGrabbable.BeingHeld;
        }

    }
}
