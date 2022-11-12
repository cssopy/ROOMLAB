using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    Animator animator;
    //public float fbspeed = 3f;
    //public float lrspeed = 3f;
    //Vector3 fb = new Vector3(0, 0, 1);
    //Vector3 lr = new Vector3(0, 1, 0);
   
    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
    }
    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        bool IsMove = moveInput.magnitude != 0;
        animator.SetBool("IsMove", IsMove);

        if (IsMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * 5f;
        }
        //float v = Input.GetAxis("Vertical") * Time.deltaTime;
        //float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        //transform.Translate(fb * v * fbspeed);y
        //transform.Rotate(lr * h * lrspeed);
    }
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        //ī�޶� ���� ��
        //�������� ȸ��
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        // �Ʒ������� ȸ��
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
        //Input.GetAxis("Mouse Y");

    }

   
      
   
}
