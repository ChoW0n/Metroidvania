using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float runSpeed = 40.0f;      //�̵� �ӵ� �� ����
    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Z))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            dash = true;
        }
    }

    public void OnFall()        //������ ó��
    {
        //animator.SetBool("IsJumping", true);
    }
    public void OnLanding()     //�ٴڿ� ����ó�� Event
    {
        //animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        //ĳ���� ������ ������ �Լ�
        //controller.Move(horizontalMove * Time.fixedDeltaTimer, jump, dash)

        jump = false;
        dash = false;
    }
}
