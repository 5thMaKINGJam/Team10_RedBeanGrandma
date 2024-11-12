using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSpeedSetter : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        // 부모 또는 상위 계층에서 Animator 컴포넌트를 찾습니다.
        anim = GetComponentInParent<Animator>();
        if (anim != null)
        {
            anim.speed = 0.5f; // 애니메이션 속도 0.5배로 설정
        }
    }

    private void OnDisable()
    {
        if (anim != null)
        {
            anim.speed = 1f; // 애니메이션 속도 원래대로 복구
        }
    }
}