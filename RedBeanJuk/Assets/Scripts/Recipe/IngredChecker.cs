using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredChecker : MonoBehaviour
{
    private int ingredPointer = 0;
    private Queue<Define.Ingredient> recipeQ;
    private Define.Ingredient curIngred;
    private bool isSuccess = true;
    private int recipeCount = 0;

    private void Awake()
    {
        RecipeManager.OnRecipeAction -= GetRecipe;
        RecipeManager.OnRecipeAction += GetRecipe;
    }

    private void OnDestroy()
    {
        RecipeManager.OnRecipeAction -= GetRecipe;
    }

    private void GetRecipe()
    {
        Debug.Log("Submit from start");
        this.recipeQ = RecipeManager.recipeQ;
        Queue<Define.Ingredient> recipeTest = new Queue<Define.Ingredient>(RecipeManager.recipeQ);
        foreach (var recipe in recipeTest)
        {
            Debug.Log($"{recipe}");
        }

        recipeCount = recipeQ.Count;
        Debug.Log($"recipeCount : {recipeCount}");
    }

    public void OnClickIngred(int ingred)
    {
        curIngred = (Define.Ingredient)ingred;

        var forCheck= Define.Ingredient.MaxCount;

        if (recipeQ.Count > 0)
        {
            forCheck = recipeQ.Peek();

            if (curIngred == recipeQ.Peek())
            {
                MoveCheck(ingredPointer);
                ingredPointer++;
                recipeQ.Dequeue();
            }
            else
            {
                isSuccess = false;
            }
        }
        else
        {
            isSuccess = false;
        }

        if (recipeQ.Count >= 0)
        {
            Debug.Log($"peek : {forCheck} curIngred : {curIngred} ingredPointer : {ingredPointer} isSuccess : {isSuccess}");
        }
        else
        {
            Debug.Log($"peek : Nothing curIngred : {curIngred} ingredPointer : {ingredPointer} isSuccess : {isSuccess}");
        }
    }

    public void OnClickSubmit()
    {
        Debug.Log($"ingredPointer : {ingredPointer} recipeCount : {recipeCount}");
        if (ingredPointer >= recipeCount && isSuccess)
        {
            Debug.Log("Success");
        }
        else { Debug.Log("Fail"); }

        isSuccess = true;
        ingredPointer = 0;
    }

    private void MoveCheck(int ingredIdx)
    {
        RecipeManager.ReciManager.MoveCheck(ingredIdx);
    }
}
