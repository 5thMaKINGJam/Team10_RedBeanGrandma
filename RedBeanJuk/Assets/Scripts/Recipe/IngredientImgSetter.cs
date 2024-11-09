using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientImgSetter : MonoBehaviour
{
    private Define.Ingredient thisIngredType;

    public void SetIngredient(Define.Ingredient ingredient, Sprite ingredImg)
    {
        SetType(ingredient);
        SetImage(ingredImg);
    }

    private void SetImage(Sprite ingredImg)
    {
        //Define.Ingredient ingredient
        Image image = this.GetComponentInChildren<Image>();
        image.sprite = ingredImg;
    }

    private void SetType(Define.Ingredient ingredient)
    {
        thisIngredType = ingredient;
    }
}
