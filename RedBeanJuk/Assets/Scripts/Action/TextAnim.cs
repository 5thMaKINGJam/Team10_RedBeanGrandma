using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnim : MonoBehaviour
{
    public Image img;
    public float scrollSpeed = 0.7f;
    private RectTransform rectTransform;
    private Vector3 startPosition;
    private Vector3 targetYPosition = new Vector3(8, -778,0);

    void Start() {
        rectTransform = img.GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        StartCoroutine(ScrollAnim());
    }

    IEnumerator ScrollAnim() {
        float startTime = Time.time;
        Vector3 targetPosition = new Vector3(startPosition.x, -778, startPosition.z);

        float duration = 10f * scrollSpeed;

        while (Time.time - startTime < duration) {
            float t = (Time.time - startTime) / duration;
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, targetYPosition, t);
            yield return null;
        }
        
        rectTransform.anchoredPosition = targetPosition;
    }
}
