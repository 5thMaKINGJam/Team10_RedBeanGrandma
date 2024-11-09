using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] RectTransform ingreidentTable;
    [SerializeField] GameObject ingreidentObj;
    [SerializeField] IngredSO ingredSO;

    public void DelIngreidentObj()
    {
        for (int i = 0; i < ingreidentTable.childCount; i++)
        {
            MoveCheck(i, false);
            ingreidentTable.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void MakeIngreidents(List<Ingredient> recipeL)
    {
        int ingredCount = recipeL.Count;
        IngredientImgSetter ingredientImgSetter;
        Sprite ingredImg;
        Transform go;

        for (int i = 0; i < ingredCount; i++)
        {
            go = ingreidentTable.GetChild(i);
            ingredientImgSetter = go.GetComponent<IngredientImgSetter>();
            ingredImg = GetImg((int)recipeL[i]);
            Debug.Log($"recipeL[i] {recipeL[i]} ingredImg {ingredImg}");
            ingredientImgSetter.SetIngredient(recipeL[i], ingredImg);
            go.gameObject.SetActive(true);
        }
    }

    private Sprite GetImg(int ingredIdx)
    {
        return ingredSO.GetIngredImg(ingredIdx);
    }

    public void MoveCheck(int ingredIdx, bool isActive = true)
    {
        Transform child = ingreidentTable.GetChild(ingredIdx);
        Transform checkChild = child.Find("Check");
        if(isActive)
            checkChild.gameObject.SetActive(true);
        else 
            checkChild.gameObject.SetActive(false);
    }
}
