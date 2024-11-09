using UnityEngine;
using UnityEngine.EventSystems;

public class IngredSpawner : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject RealIngred;

    public void OnPointerDown(PointerEventData eventData)
    {
        RealIngred.SetActive(true);
    }
}
