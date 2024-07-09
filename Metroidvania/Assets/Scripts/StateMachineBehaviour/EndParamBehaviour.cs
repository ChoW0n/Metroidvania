using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour  //스테이트 머신 Behavior
{
    public string parameter = "IsAttacking";        //애니메이터에서 저장한 파라미터 값을 설정

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, false);
    }
}
