using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveIngredients : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField]
    float dragSpeed = 1.0f;

    private RectTransform rectTransform;
    private Vector3 startPosition;
    public List<string> addedIngredients = new List<string>();
    public float minDis= 0.1f;
    public GameObject pot;

    void Start() {
        startPosition = transform.position;
    }
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        
        rectTransform.anchoredPosition += eventData.delta * dragSpeed;
    }
    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        string currentIngName = gameObject.name;

        if (IsOverlapping(rectTransform, pot.GetComponent<RectTransform>())) {
            if(Enum.TryParse(currentIngName, true, out Define.Ingredient ingred))
            {
                Debug.Log($"{currentIngName}");
                IngredChecker.ingredChecker.IngredEntered(ingred);
            }
            transform.position = startPosition;
        }
        // if(Vector3.Distance(pot.transform.position, transform.position) < minDis) {
        //     AddIngredient(currentIngName);
        //     Debug.Log("add");
        //     transform.position = startPosition;
        //     // Destroy(gameObject);
        // }
    }

    private bool IsOverlapping(RectTransform rectA, RectTransform rectB) {
        Vector3[] cornersA = new Vector3[4];
        rectA.GetWorldCorners(cornersA);

        Vector3[] cornersB = new Vector3[4];
        rectB.GetWorldCorners(cornersB);

        return (cornersA[0].x <cornersB[2].x && cornersA[2].x>cornersB[0].x && cornersA[0].y<cornersB[1].y && cornersA[1].y>cornersB[0].y);
    }
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
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
