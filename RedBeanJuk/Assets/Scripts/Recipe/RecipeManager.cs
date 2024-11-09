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

    public static RecipeManager ReciManager { get; private set; }
    private void Awake()
    {
        if (ReciManager == null)
        {
            ReciManager = this;
        }
        else { Destroy(gameObject); }
    }

    public void OnClickSubmit()
    {
        DeleteRecipe();

        int peerIdx = GetPeer();
        NextPeer(peerIdx);
        NextRecipe(maxLevel, peerIdx);
    }

    public void OnClickNextLevel()
    {
        maxLevel = UnityEngine.Random.Range(0, (int)Ingredient.MaxCount);
    }

    private int GetPeer() // Get random peer
    {
        return UnityEngine.Random.Range(0, (int)Peer.MaxCount);
    }

    private void DeleteRecipe()
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
        Queue<Ingredient> recipeQ = customerData.GetPeerRecipe(maxLevel, peerIdx);
        List<Ingredient> recipeL = recipeQ.ToList();

        foreach (var ingred in recipeL)
        {
            ingredientManager.MakeIngreidentObj(ingred);
        }
    }
}
