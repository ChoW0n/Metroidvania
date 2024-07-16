using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2.0f;    //ī�޶� ĳ���͸� ���󰡴� ���ǵ�
    public Transform Target;

    private Transform canTransform;     //Ÿ�� Ʈ������

    public float shakeDuration = 0.0f;  //ī�޶��� Ʈ������
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;        //���� ��ġ
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
