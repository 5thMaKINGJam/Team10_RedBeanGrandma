using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 현재 포커스된 UI가 있다면 기본 `Submit` 액션 무시
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                // 원하는 동작을 수행하거나 키 입력을 무시
                return;
            }
        }
    }
}
