using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    //public moveIngredients moveIng;
    public List<string> recipe;
    public bool IsClear(List<string> recipe, List<string> addedIngredients) {

        if (recipe.Count != addedIngredients.Count){
            return false;
        }
        
        for (int i=0; i<recipe.Count; i++) {
            if (recipe[i] != addedIngredients[i]) {
                return false;
            } 
        }

        return true;
    }

    void ResetIngredients() {
        //moveIng.addedIngredients.Clear();
    }

    void ResetRecipe() {
        recipe.Clear();
    }

    private void OnMouseDown() {
            //if (IsClear(recipe, moveIng.addedIngredients)) {
            //    Debug.Log("clear");
            //} else {
            //    Debug.Log("fail");
            //}
        
        ResetIngredients(); ResetRecipe();    
    }
}
