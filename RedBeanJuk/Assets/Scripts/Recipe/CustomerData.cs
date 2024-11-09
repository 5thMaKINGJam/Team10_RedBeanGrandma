using System;
using System.Collections.Generic;
using static Define;

public class CustomerData
{
    private static readonly Dictionary<Peer, Ingredient> peerIngredientMap = new Dictionary<Peer, Ingredient>
    {
        { Peer.Bam, Ingredient.Seoltang },
        { Peer.Songot, Ingredient.Sogeum },
        { Peer.Jara, Ingredient.Saealsim },
        { Peer.Jinhuk, Ingredient.Chapssal },
        { Peer.Jeolgu, Ingredient.Jat }
    };

    private Queue<Ingredient> recipeQ = new Queue<Ingredient>();

    public Queue<Ingredient> GetPeerRecipe(int maxIngredients, int peer)
    {
        recipeQ.Clear(); // Clear the queue at the beginning

        int peerNum = peer;

        PutBaseIngredient(peerNum);
        GetRandIngredient(maxIngredients);
        ShuffleRecipe();

        return new Queue<Ingredient>(recipeQ); // Return a new queue to avoid external modifications
    }

    private void ShuffleRecipe()
    {
        // Convert recipeQ to a list
        List<Ingredient> list = new List<Ingredient>(recipeQ);
        // Shuffle the list
        for (int i = 0; i < list.Count; i++)
        {
            int randIndex = UnityEngine.Random.Range(i, list.Count);
            // Swap list[i] and list[randIndex]
            Ingredient temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
        // Clear recipeQ and enqueue shuffled items
        recipeQ.Clear();
        foreach (var ingredient in list)
        {
            recipeQ.Enqueue(ingredient);
        }
    }

    private void PutBaseIngredient(int peer)
    {
        Peer peerEnum = (Peer)peer;
        recipeQ.Enqueue(Ingredient.Mabssal);
        recipeQ.Enqueue(peerIngredientMap[peerEnum]);
    }

    private void GetRandIngredient(int maxRange) // Put random ingredients into recipe
    {
        int count = UnityEngine.Random.Range(0, maxRange);
        Ingredient[] ingredients = (Ingredient[])Enum.GetValues(typeof(Ingredient));
        int ingredientCount = ingredients.Length - 1; // Exclude MaxCount

        for (int i = 0; i < count; i++)
        {
            int idx = UnityEngine.Random.Range(0, ingredientCount);
            recipeQ.Enqueue(ingredients[idx]);
        }
    }
}
