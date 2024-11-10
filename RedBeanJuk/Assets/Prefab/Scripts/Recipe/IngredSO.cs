using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredSO", menuName = "ScriptableObjects/IngredSO", order = 1)]
public class IngredSO : ScriptableObject
{
    [SerializeField] private List<Sprite> IngredImg;

    public Sprite GetIngredImg(int IngredIdx)
    {
        if (IngredIdx < IngredImg.Count)
        {
            return IngredImg[IngredIdx];
        }
        else
        {
            Debug.Log("Idx out of array in image");
            return null;
        } 
    }
}