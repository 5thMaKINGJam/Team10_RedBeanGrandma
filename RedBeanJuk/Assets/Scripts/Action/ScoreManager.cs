using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Cooking cooking;
    public moveIngredients moveIng;
    public GameObject addedpot;
 
    private Vector3 nextpotPos = new Vector3(156, 77, 0);
    void addScore() {
        if (cooking.IsClear(cooking.recipe, moveIng.addedIngredients) == true) {
            AddObj();
            Debug.Log("clear");
        } else {
            Debug.Log("fail");
        }
    }

    void AddObj() {
        Instantiate(addedpot, nextpotPos, Quaternion.identity);
        nextpotPos.x += 17;
    }

    private void OnMouseDown() {
        Debug.Log("check");
        AddObj();
    }
    
    // Start is called before the first frame update
    
}
