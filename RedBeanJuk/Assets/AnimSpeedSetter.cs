using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSpeedSetter : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        // �θ� �Ǵ� ���� �������� Animator ������Ʈ�� ã���ϴ�.
        anim = GetComponentInParent<Animator>();
        if (anim != null)
        {
            anim.speed = 0.5f; // �ִϸ��̼� �ӵ� 0.5��� ����
        }
    }

    private void OnDisable()
    {
        if (anim != null)
        {
            anim.speed = 1f; // �ִϸ��̼� �ӵ� ������� ����
        }
    }
}