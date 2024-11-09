using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PeerSO", menuName = "ScriptableObjects/PeerSO", order = 2)]
public class PeerSO : ScriptableObject
{
    [SerializeField] private List<Sprite> PeerImg;

    public Sprite GetIngredImg(int IngredIdx)
    {
        if (IngredIdx < PeerImg.Count)
        {
            return PeerImg[IngredIdx];
        }
        else
        {
            Debug.Log("Idx out of array in image");
            return null;
        } 
    }
}