using UnityEngine;
using UnityEngine.EventSystems;

public class OnHovering : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject go;
    public void OnPointerEnter(PointerEventData eventData)
    {
        go.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        go.transform.localScale = Vector3.one;
    }
}
