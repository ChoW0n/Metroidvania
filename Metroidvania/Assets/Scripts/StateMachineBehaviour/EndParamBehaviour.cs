using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour  //������Ʈ �ӽ� Behavior
{
    public string parameter = "IsAttacking";        //�ִϸ����Ϳ��� ������ �Ķ���� ���� ����

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, false);
    }
}
