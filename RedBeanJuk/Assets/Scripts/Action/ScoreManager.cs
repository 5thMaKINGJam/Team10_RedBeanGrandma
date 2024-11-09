using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Cooking cooking;
    public moveIngredients moveIng;
    public GameObject addedpot;
 
    
    void addScore() {
        if (cooking.IsClear(cooking.recipe, moveIng.addedIngredients) == true) {
            AddObj();
            Debug.Log("clear");
        } else {
            Debug.Log("fail");
        }
    }

    public Transform canvasTransform;
    private Vector3 nextpotPos = new Vector3(603, 275, 0);
    void AddObj() {
        GameObject obj = Instantiate(addedpot, canvasTransform);
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        obj.SetActive(true);
        if (rectTransform != null) {
            rectTransform.anchoredPosition = nextpotPos;
        }
        nextpotPos.x += 17;  
    }


    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("test");
            AddObj();
        }
        
    }
    
}
