using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void LoadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial_ing");
    }

    public void OnPointerEnter(PointerEventData eventData) {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transform.localScale = Vector3.one;
    }
}
