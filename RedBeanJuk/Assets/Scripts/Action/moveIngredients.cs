using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveIngredients : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    void Start() {
        Vector3 startPosition = transform.position;
    }
    private RectTransform rectTransform;
    public List<string> addedIngredients = new List<string>();
    public float minDis= 0.1f;
    public GameObject pot;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        string currentIngName = gameObject.name;
        if(Vector3.Distance(pot.transform.position, transform.position) < minDis) {
            AddIngredient(currentIngName);
            transform.position = startPosition;
            // Destroy(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public void AddIngredient(string ingredientName) {
        addedIngredients.Add(ingredientName);
        Debug.Log("아이템 추가");
    }

    // IDragHandler, IEndDragHandler
    // public List<string> addedIngredients = new List<string>();
    // public float minDis= 0.1f;
    // public GameObject pot;
    // public void OnDrag(PointerEventData eventData) {
    //     transform.position = eventData.position;
    //     Debug.Log("dragging");
    // }

    // public void AddIngredient(string ingredientName) {
    //     addedIngredients.Add(ingredientName);
    //     Debug.Log("아이템 추가");
    // }

    // public void OnEndDrag(PointerEventData eventData){
    //     string currentIngName = gameObject.name;

    //     Debug.Log("end drag");

    //     if(Vector3.Distance(pot.transform.position, transform.position) < minDis) {
    //         AddIngredient(currentIngName);
    //         Destroy(gameObject);
    //     }
    // }

}
