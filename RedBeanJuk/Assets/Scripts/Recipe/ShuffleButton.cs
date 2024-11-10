using System.Collections.Generic;
using UnityEngine;

public class ShuffleButton : MonoBehaviour
{
    /// <summary>
    /// 부모 오브젝트의 자식 GameObject들의 순서를 랜덤으로 섞는 함수
    /// </summary>
    public void ShuffleChildren()
    {
        // 1. 부모 오브젝트의 모든 자식 Transform을 리스트에 수집
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        // 2. Fisher-Yates Shuffle 알고리즘을 사용하여 리스트 섞기
        for (int i = 0; i < children.Count; i++)
        {
            Transform temp = children[i];
            int randomIndex = Random.Range(i, children.Count);
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        // 3. 섞인 리스트 순서대로 자식 GameObject의 Sibling Index 재설정
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }

    // 추가적인 기능을 원한다면 여기에 구현할 수 있습니다.
}
