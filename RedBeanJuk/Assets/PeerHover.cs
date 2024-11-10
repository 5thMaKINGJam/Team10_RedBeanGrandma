using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeerHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isGameStarted = false;

    void Start() {
        isGameStarted = true;
    }
    
    public void OnPointerEnter(PointerEventData eventData) {
        if (!isGameStarted) return;
        Debug.Log("detect");
        if (transform.childCount == 1) {
            Transform child = transform.GetChild(0);
            child.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        } else {
            Debug.Log("not one");
        }
       
    }

        public void OnPointerExit(PointerEventData eventData) {
        if (!isGameStarted) return;
        if (transform.childCount == 1) {
            Transform child = transform.GetChild(0);
            child.localScale = Vector3.one;
        } else {
            Debug.Log("not one");
        }
       
    }

}
