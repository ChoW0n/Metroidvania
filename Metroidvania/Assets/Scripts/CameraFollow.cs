using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2.0f;    //카메라가 캐릭터를 따라가는 스피드
    public Transform Target;

    private Transform canTransform;     //타겟 트랜스폼

    public float shakeDuration = 0.0f;  //카메라의 트랜스폼
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;        //원본 위치
    // Start is called before the first frame update
    void Start()
    {
        //originalPos = canTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
