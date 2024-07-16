using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterMovement controller;
    public Animator animator;

    public float runSpeed = 40.0f;      //�̵� �ӵ� �� ����
    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash = true;
        }
    }

    public void OnFall()        //������ ó��
    {
        animator.SetBool("IsJumping", true);
    }
    public void OnLanding()     //�ٴڿ� ����ó�� Event
    {
        animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        //ĳ���� ������ ������ �Լ�
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);

        jump = false;
        dash = false;
    }
}
