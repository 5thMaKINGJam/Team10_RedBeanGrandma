using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Define;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] IngredientManager ingredientManager;
    [SerializeField] PeerManager peerManager;
    [SerializeField] private int maxLevel;
    private CustomerData customerData = new CustomerData();

    public static Queue<Ingredient> recipeQ;
    public static Action OnRecipeAction;

    public static RecipeManager ReciManager { get; private set; }
    private void Awake()
    {
        if (ReciManager == null)
        {
            ReciManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        MakeOrder();
    }

    public void OnClickSubmit(bool isSuccess)
    {
        DeleteRecipe(isSuccess);
        MakeOrder();
    }

    public void OnClickNextLevel()
    {
        maxLevel = UnityEngine.Random.Range(0, (int)Ingredient.MaxCount);
    }

    private void MakeOrder()
    {
        int peerIdx = GetPeer();
        NextPeer(peerIdx);
        NextRecipe(maxLevel, peerIdx);
    }

    private int GetPeer() // Get random peer
    {
        return UnityEngine.Random.Range(0, (int)Peer.MaxCount);
    }

    private void DeleteRecipe(bool isSuccess)
    {
        ingredientManager.DelIngreidentObj();
        peerManager.DelPeerObj(isSuccess);
    }

    private void NextPeer(int peerIdx)
    {
        Peer peerEnum = (Peer)peerIdx;
        peerManager.MakePeerObj(peerEnum);
    }

    private void NextRecipe(int maxLevel, int peerIdx)
    {
        recipeQ = customerData.GetPeerRecipe(maxLevel, peerIdx);
        Debug.Log("Submit from start");
        OnRecipeAction.Invoke();

        List<Ingredient> recipeL = recipeQ.ToList();

        foreach (var ingred in recipeL)
        {
            ingredientManager.MakeIngreidentObj(ingred);
        }
    }

    public void MoveCheck(int ingredIdx)
    {
        ingredientManager.MoveCheck(ingredIdx);
    }
}
