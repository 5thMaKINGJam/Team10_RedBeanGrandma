using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���� ��Ŀ���� UI�� �ִٸ� �⺻ `Submit` �׼� ����
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                // ���ϴ� ������ �����ϰų� Ű �Է��� ����
                return;
            }
        }
    }
}
