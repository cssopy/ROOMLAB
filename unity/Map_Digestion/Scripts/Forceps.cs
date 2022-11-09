using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Forceps : GrabbableEvents
{
    // ������ �׷� ������
    Transform GrabbTarget;
    // ó�� ���� ������ ( �ι� ������ �ʵ��� )
    Transform Delay_Target;
    // �ɼ� �� �κ� ������
    public Transform child;
    //public override void OnTrigger(float triggerValue)
    //{
    //    if (GrabbTarget != null)
    //    {
    //        if (triggerValue < 0.5f)
    //        {
    //            //�������� 
    //            //Ÿ���� �ִٸ�
    //            GrabbTarget.parent = child;
    //            GrabbTarget.localPosition = Vector3.zero;
    //            GrabbTarget.rotation = child.rotation;
    //        }
    //        else
    //        {
    //            //�� �������� 
    //            //�ڽ����� �־���� �ֵ��� �����·�
    //        }
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.CompareTag("PinSet_Get"))
    //        GrabbTarget = other.transform;
    //}

    // vr���� ��ư�� ������ ��
    public override void OnTriggerDown()
    {
        // ���� GrabbTarget�� �ִٸ�
        if (GrabbTarget != null)
        {
            // �ش� Ÿ���� ���� �߷°���, �ݶ��̴� ���� �Ͻ������� ���ش�.
            GrabbTarget.GetComponent<Rigidbody>().isKinematic = true;
            GrabbTarget.GetComponent<MeshCollider>().enabled = false;
            // �ش� Ÿ���� �θ�� ������Ʈ�� �ɼ�����
            GrabbTarget.parent = child;
        }
    }

    // ��ư���� ���� ���� ��
    public override void OnTriggerUp()
    {
        // ���� GrabbTarget�� �ִٸ�
        if(GrabbTarget != null)
        {
            // �ش� Ÿ���� �±׸� Default�� �ٲ㼭 Onion_Pos�� ��� OnTriggerEnter�� if�� ���ؿ��� �����.
            GrabbTarget.tag = "Default";
            // �±װ� Default�� �Ǹ� 3.0�� ���Ŀ� �ٽ� Onion_Pos�� ����
            StartCoroutine(tag_Delay(GrabbTarget));
            // �ش� ������Ʈ�� ���� �߷°���, �޽� �ݶ��̴��� �ٽ� Ȱ��ȭ ��Ų��.
            GrabbTarget.GetComponent<Rigidbody>().isKinematic = false;
            GrabbTarget.GetComponent<MeshCollider>().enabled = true;

            // �θ� ������Ʈ�� null��
            GrabbTarget.SetParent(null);
            // �ٸ� ��ü�� ���� �� �ְ� GrabbTarget�� �ٽ� null�� ���� ��Ų��.
            GrabbTarget = null;
        }
    }

    // �±� ���� �ڷ�ƾ
    IEnumerator tag_Delay(Transform T)
    {
        yield return new WaitForSeconds(3.0f);
        T.tag = "Onion_Tree";
    }

    // �� Ʈ���� ������ �浹 ��
    private void OnTriggerEnter(Collider other)
    { 
        // ���� �浹�� ������Ʈ�� �±װ� Onion_Tree�̰�, GrabbTarget�� ���� null�̸� �浹�� Ʈ������ ���� Delay_Target�� ���� ���� ������ ����
        if(other.CompareTag("Onion_Tree") && GrabbTarget == null && other.transform != Delay_Target)
        {
            // GrabbTarget���� �浹�� Ÿ�� �� ����
            GrabbTarget = other.transform;
            // Delay_Target���� �浹�� Ÿ�� �� ����
            Delay_Target = GrabbTarget;
            // Delay_Target�� ���� �ð� ���Ŀ� null������ �ٲپ ��Ҵ� ��ü�� �ٽ� ���� �� �ְ� �ϴ� �ڷ�ƾ
            StartCoroutine(Delay_Target_Reset());
        }
    }

    // 2�� �� Delay_Target���� ���� �ȴ�.
    IEnumerator Delay_Target_Reset()
    {
        yield return new WaitForSeconds(2.0f);
        Delay_Target = null;
    }

}








