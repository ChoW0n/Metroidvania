using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float duration; //���� �ð�
    private float remainingTime; //���� �ð�
    private bool isRunning;     //���� ������ �Ǵ�

    public Timer(float duration)    //Ŭ���� ������ [Ŭ������ ������� �� �ʱ�ȭ]
    {
        this.duration = duration;
        this.remainingTime = duration;
        this.isRunning = false;
    }

    // Start is called before the first frame update
    public void Start()     //��ŸƮ �����ֱ⿡�� ����Ҷ� ���� ���� ���ִ� �Լ�
    {
        this.remainingTime = duration;
        this.isRunning = true;
    }

    // Update is called once per frame
    public void Update(float deltaTime)     //Update �Լ����� DeltaTime�� �޾ƿ´�.
    {
        if (isRunning)      //���� ���̸�
        {
            remainingTime -= deltaTime;     //�޾ƿ� DeltaTime�� ���ҽ�Ų��.
            if (remainingTime <= 0)         //�ð��� �� �Ҹ� �Ǹ�
            {
                isRunning = false;          //���� ����
                remainingTime = 0;          //���� �ð� 0
            }
        }
    }

    public bool IsRunning() //���� �� Ȯ�� �Լ�
    {
        return isRunning;   //���� ���� ����
    }
    public float GetRemainingTime() //�����ִ� �ð� Ȯ�� �Լ�
    {
        return remainingTime;   //�ð� ���� ����
    }
    public void Reset()
    {
        this.remainingTime = duration;
        this.isRunning = false;
    }
}
