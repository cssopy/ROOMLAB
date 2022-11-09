using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Forceps : GrabbableEvents
{
    // 잡히는 그랩 오브젝
    Transform GrabbTarget;
    // 처음 잡힌 오브젝 ( 두번 잡히지 않도록 )
    Transform Delay_Target;
    // 핀셋 끝 부분 오브젝
    public Transform child;
    //public override void OnTrigger(float triggerValue)
    //{
    //    if (GrabbTarget != null)
    //    {
    //        if (triggerValue < 0.5f)
    //        {
    //            //눌렸을때 
    //            //타겟이 있다면
    //            GrabbTarget.parent = child;
    //            GrabbTarget.localPosition = Vector3.zero;
    //            GrabbTarget.rotation = child.rotation;
    //        }
    //        else
    //        {
    //            //안 눌렸을때 
    //            //자식으로 넣어놓은 애들을 원상태로
    //        }
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.CompareTag("PinSet_Get"))
    //        GrabbTarget = other.transform;
    //}

    // vr에서 버튼을 눌렀을 때
    public override void OnTriggerDown()
    {
        // 만약 GrabbTarget이 있다면
        if (GrabbTarget != null)
        {
            // 해당 타겟이 가진 중력값과, 콜라이더 값을 일시적으로 없앤다.
            GrabbTarget.GetComponent<Rigidbody>().isKinematic = true;
            GrabbTarget.GetComponent<MeshCollider>().enabled = false;
            // 해당 타겟의 부모격 오브젝트를 핀셋으로
            GrabbTarget.parent = child;
        }
    }

    // 버튼에서 손을 뗏을 때
    public override void OnTriggerUp()
    {
        // 만약 GrabbTarget이 있다면
        if(GrabbTarget != null)
        {
            // 해당 타겟의 태그를 Default로 바꿔서 Onion_Pos만 잡는 OnTriggerEnter의 if문 기준에서 벗어난다.
            GrabbTarget.tag = "Default";
            // 태그가 Default가 되면 3.0초 이후에 다시 Onion_Pos로 변경
            StartCoroutine(tag_Delay(GrabbTarget));
            // 해당 오브젝트가 가진 중력값과, 메쉬 콜라이더를 다시 활성화 시킨다.
            GrabbTarget.GetComponent<Rigidbody>().isKinematic = false;
            GrabbTarget.GetComponent<MeshCollider>().enabled = true;

            // 부모 오브젝트를 null로
            GrabbTarget.SetParent(null);
            // 다른 물체를 잡을 수 있게 GrabbTarget을 다시 null로 변경 시킨다.
            GrabbTarget = null;
        }
    }

    // 태그 변경 코루틴
    IEnumerator tag_Delay(Transform T)
    {
        yield return new WaitForSeconds(3.0f);
        T.tag = "Onion_Tree";
    }

    // 두 트리거 사이의 충돌 시
    private void OnTriggerEnter(Collider other)
    { 
        // 만약 충돌된 오브젝트의 태그가 Onion_Tree이고, GrabbTarget의 값이 null이며 충돌된 트랜스폼 값이 Delay_Target과 같지 않을 때에만 실행
        if(other.CompareTag("Onion_Tree") && GrabbTarget == null && other.transform != Delay_Target)
        {
            // GrabbTarget값에 충돌된 타겟 값 대입
            GrabbTarget = other.transform;
            // Delay_Target값에 충돌된 타겟 값 대입
            Delay_Target = GrabbTarget;
            // Delay_Target을 일정 시간 이후에 null값으로 바꾸어서 잡았던 물체를 다시 잡을 수 있게 하는 코루틴
            StartCoroutine(Delay_Target_Reset());
        }
    }

    // 2초 뒤 Delay_Target값이 널이 된다.
    IEnumerator Delay_Target_Reset()
    {
        yield return new WaitForSeconds(2.0f);
        Delay_Target = null;
    }

}








