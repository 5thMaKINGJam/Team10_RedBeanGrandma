using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    void AddObj() {
        Vector3 addPos = new Vector3(0, 0, 0); //ui 나오면 수정
        Instantiate(addedpot, addPos, Quaternion.identity);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
