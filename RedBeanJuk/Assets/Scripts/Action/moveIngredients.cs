using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveIngredients : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField]float dragSpeed = 3.0f;
    [SerializeField] RectTransform bg;

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

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnDrag(PointerEventData eventData) {       
        rectTransform.anchoredPosition += eventData.delta * dragSpeed;
    }
    public void OnEndDrag(PointerEventData eventData) {
        string currentIngName = gameObject.name;

        if (IsOverlapping(rectTransform, pot.GetComponent<RectTransform>())) {
            if(Enum.TryParse(currentIngName, true, out Define.Ingredient ingred))
            {
                Debug.Log($"{currentIngName}");
                IngredChecker.ingredChecker.IngredEntered(ingred);
            }
        }
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        rectTransform.anchoredPosition = Vector2.zero;
    }

    private bool IsOverlapping(RectTransform rectA, RectTransform rectB) {
        Vector3[] cornersA = new Vector3[4];
        rectA.GetWorldCorners(cornersA);

        Vector3[] cornersB = new Vector3[4];
        rectB.GetWorldCorners(cornersB);

        return (cornersA[0].x <cornersB[2].x && cornersA[2].x>cornersB[0].x && cornersA[0].y<cornersB[1].y && cornersA[1].y>cornersB[0].y);
    }
}
