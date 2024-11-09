using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Vector2Int vector2int = new Vector2Int(603, 275);
    [SerializeField] GameObject Naembi;
    [SerializeField] RectTransform scoreTransform;
    private Vector3 nextpotPos;

    private void Start()
    {
        nextpotPos = new Vector3(vector2int.x, vector2int.y, 0);
    }
    public void AddObj() {
        GameObject obj = Instantiate(Naembi, scoreTransform);
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        obj.SetActive(true);
        if (rectTransform != null) {
            rectTransform.anchoredPosition = nextpotPos;
        }
        nextpotPos.x += 17;  
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("test");
            AddObj();
        }        
    }
    
}
