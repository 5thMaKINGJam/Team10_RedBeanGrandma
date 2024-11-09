using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveIngredients : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public List<string> addedIngredients = new List<string>();
    public float minDis= 0.1f;
    public GameObject pot;
    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
        Debug.Log("dragging");
    }

    public void AddIngredient(string ingredientName) {
        addedIngredients.Add(ingredientName);
        Debug.Log("아이템 추가");
    }

    public void OnEndDrag(PointerEventData eventData){
        string currentIngName = gameObject.name;

        Debug.Log("end drag");

        if(Vector3.Distance(pot.transform.position, transform.position) < minDis) {
            AddIngredient(currentIngName);
            Destroy(gameObject);
        }
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
