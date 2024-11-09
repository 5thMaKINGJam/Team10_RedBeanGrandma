using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PeerSO", menuName = "ScriptableObjects/PeerSO", order = 2)]
public class PeerSO : ScriptableObject
{
    [SerializeField] private List<Sprite> PeerImg;

    public Sprite GetPeerImg(int IngredIdx)
    {
        Debug.Log($"index : {IngredIdx}");
        if (IngredIdx < PeerImg.Count)
        {
            Debug.Log($"{IngredIdx}번째 거야!");
            return PeerImg[IngredIdx];
        }
        else
        {
            Debug.Log("Idx out of array in image");
            return null;
        } 
    }

    public int GetPeerIdx() 
    {
        return PeerImg.Count;   
    }
}