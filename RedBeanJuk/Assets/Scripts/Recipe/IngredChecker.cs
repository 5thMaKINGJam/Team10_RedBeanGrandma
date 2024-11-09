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
    private int delay = 1;

    public static IngredChecker ingredChecker { get; private set; }
    [SerializeField] NaembiSpawner naembispawner;
    [SerializeField] PotStateSetter stateSetter;

    private void Awake()
    {
        if (ingredChecker == null)
        {
            ingredChecker = this;
        }
        else { Destroy(gameObject); }

        RecipeManager.OnRecipeAction -= GetRecipe;
        RecipeManager.OnRecipeAction += GetRecipe;
    }

    private void OnDestroy()
    {
        RecipeManager.OnRecipeAction -= GetRecipe;
    }

    private void GetRecipe()
    {
        this.recipeQ = RecipeManager.recipeQ;
        Queue<Define.Ingredient> recipeTest = new Queue<Define.Ingredient>(RecipeManager.recipeQ);
        foreach (var recipe in recipeTest)
        {
            Debug.Log($"{recipe}");
        }

        recipeCount = recipeQ.Count;
        Debug.Log($"recipeCount : {recipeCount}");
    }

    public void OnClickTest(int ingredIdx)
    {
        IngredEntered((Define.Ingredient)ingredIdx);
    }

    public void IngredEntered(Define.Ingredient ingred)
    {
        curIngred = ingred;

        var forCheck = Define.Ingredient.MaxCount;

        if (recipeQ.Count > 0)
        {
            forCheck = recipeQ.Peek();

            if (curIngred == recipeQ.Peek())
            {
                stateSetter.SetBoilingState(1);//fail
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
        if (!isSuccess)
        {
            stateSetter.SetBoilingState(3);//fail
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
        bool evalSuccess;
        if (ingredPointer >= recipeCount && isSuccess)
        {
            evalSuccess = true;
            GameManager.Instance.IncreaseBowl();
            naembispawner.ShowNaembi();
            stateSetter.SetBoilingState(2);//success
            Debug.Log("Success");
        }
        else
        {
            evalSuccess = false;
            stateSetter.SetBoilingState(3);//fail
            Debug.Log("Fail");
        }

        RecipeManager.ReciManager.peerManager.EvalPeerObj(evalSuccess);
        StartCoroutine(DeleteOrder(delay));

        isSuccess = true;
        ingredPointer = 0;
    }

    private IEnumerator DeleteOrder(float delay)//2�� ��
    { 
        yield return new WaitForSeconds(delay);
        stateSetter.SetBoilingState(0);//none
        RecipeManager.ReciManager.OnClickNext();
    }

    private void MoveCheck(int ingredIdx)
    {
        RecipeManager.ReciManager.MoveCheck(ingredIdx);
    }
}
