using System.Collections.Generic;
using UnityEngine;

public class ShuffleButton : MonoBehaviour
{
    /// <summary>
    /// �θ� ������Ʈ�� �ڽ� GameObject���� ������ �������� ���� �Լ�
    /// </summary>
    public void ShuffleChildren()
    {
        // 1. �θ� ������Ʈ�� ��� �ڽ� Transform�� ����Ʈ�� ����
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        // 2. Fisher-Yates Shuffle �˰����� ����Ͽ� ����Ʈ ����
        for (int i = 0; i < children.Count; i++)
        {
            Transform temp = children[i];
            int randomIndex = Random.Range(i, children.Count);
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        // 3. ���� ����Ʈ ������� �ڽ� GameObject�� Sibling Index �缳��
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }

    // �߰����� ����� ���Ѵٸ� ���⿡ ������ �� �ֽ��ϴ�.
}
