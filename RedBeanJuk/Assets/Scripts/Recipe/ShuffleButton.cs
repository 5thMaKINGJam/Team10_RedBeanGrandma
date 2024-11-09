using System.Collections.Generic;
using UnityEngine;

public class ShuffleButton : MonoBehaviour
{
    private List<Vector3> btnPos = new List<Vector3>();
    private List<int> idx = new List<int>();

    private void Awake()
    {
        Initialized();
    }

    private void Initialized()
    {
        foreach (Transform child in transform)
        {
            btnPos.Add(child.position);
        }

        for (int i = 0; i < btnPos.Count; i++)
        { 
            idx.Add(i);
        }
    }

    public void ShuffleIngred()
    {
        ShuffleIdx(idx);
        ShuffleBtn();
    }

    private void ShuffleBtn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.position = btnPos[idx[i]];
            transform.GetChild(i).GetComponent<moveIngredients>().SetStart(btnPos[idx[i]]);
        }
    }

    private void ShuffleIdx(List<int> list)
    {
        // Shuffle the list
        for (int i = 0; i < list.Count; i++)
        {
            int randIndex = UnityEngine.Random.Range(i, list.Count);
            // Swap list[i] and list[randIndex]
            int temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }
}
