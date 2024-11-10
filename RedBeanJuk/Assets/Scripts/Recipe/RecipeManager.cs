using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Define;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] IngredientManager ingredientManager;
    public PeerManager peerManager;
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
    }

    public void SetMaxgred(int maxgred)
    { 
        maxLevel = maxgred;
        MakeOrder();
    }

    private bool isStop=false;
    public void OnClickNext()
    {
        DeleteRecipe();
        if (isStop)
        {
            StartCoroutine(WaitAndMakeOrder());
        }
        else
        {
            MakeOrder();
        }
    }

    public void SetStop(bool stop)
    {
        isStop = stop;
    }

    private IEnumerator WaitAndMakeOrder()
    {
        // isStop이 false가 될 때까지 대기
        yield return new WaitUntil(() => !isStop);
        MakeOrder();
    }

    public void OnClickNextLevel()
    {
        maxLevel = UnityEngine.Random.Range(0, (int)Ingredient.MaxCount);
    }

    public void MakeOrder()
    {
        int peerIdx = GetPeer();
        NextPeer(peerIdx);
        NextRecipe(maxLevel, peerIdx);
    }

    private int GetPeer() // Get random peer
    {
        return UnityEngine.Random.Range(0, (int)Peer.MaxCount);
    }

    public void DeleteRecipe()
    {
        ingredientManager.DelIngreidentObj();
        peerManager.DelPeerObj();
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
        ingredientManager.MakeIngreidents(recipeL);
    }

    public void MoveCheck(int ingredIdx)
    {
        ingredientManager.MoveCheck(ingredIdx);
    }
}
