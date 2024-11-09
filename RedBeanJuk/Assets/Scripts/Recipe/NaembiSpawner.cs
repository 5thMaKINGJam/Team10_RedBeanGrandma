using UnityEngine;

public class NaembiSpawner : MonoBehaviour
{
    [SerializeField] GameObject Naembi;
    private int maxBowl = 10;
    private int add;
    private int vecX;
    private int curBowl;

    private RectTransform rectParent;

    void Start()
    {
        rectParent= this.gameObject.GetComponentInParent<RectTransform>();
        SpawnNaembi(rectParent);
        curBowl = 0;
    }

    private void SpawnNaembi(RectTransform rectParent)
    {
        add = (int)(rectParent.rect.width / (maxBowl + 2));
        vecX = 8;// (int)(rectParent.rect.width - add * 3) - 8;

        for (int i = 0; i < maxBowl; i++)
        {
            GameObject clonedObj = Instantiate(Naembi);
            clonedObj.transform.SetParent(rectParent, false);
            clonedObj.SetActive(false);

            //Anchore preset middle left로 설정
            RectTransform rectTransform = clonedObj.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 0.5f);
            rectTransform.anchorMax = new Vector2(0, 0.5f);
            rectTransform.pivot = new Vector2(0, 0.5f);

            //clondedObj의 x 위치는 vecX
            rectTransform.anchoredPosition = new Vector2(vecX, rectTransform.anchoredPosition.y);

            vecX += add;
        }
    }

    
    public void ShowNaembi()
    {
        if (curBowl <10)
        {
            rectParent.GetChild(curBowl).gameObject.SetActive(true);
            curBowl++;
        }
        else { Debug.Log("Max 10!"); }
    }
}
