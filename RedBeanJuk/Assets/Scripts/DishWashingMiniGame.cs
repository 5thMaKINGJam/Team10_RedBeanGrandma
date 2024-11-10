using System.Collections;
using UnityEngine;

public class DishWashingMiniGame : MonoBehaviour
{

    public GameObject[] Bubbles;
    public GameObject AlertPanel;

    private int count = 0;
    private int BubbleLength;

    private void Start() {
        BubbleLength = Bubbles.Length;
        StartCoroutine(Alertmsg());

    }
    private IEnumerator Alertmsg()
    {
        AlertPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        AlertPanel.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            foreach (var bubble in Bubbles)
                bubble.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            //Bubbles들이 KeyDown일 때는 scale 1.2로 커지고, KeyUp일 때나 평상시에는 scale 1임
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (var bubble in Bubbles)
                bubble.transform.localScale = Vector3.one; // 거품 크기 원래대로 (1배)
        }

        for (int i = 0; i < Bubbles.Length; i++)
        {
            if (count == 8 * (i + 1))
            {
                Bubbles[i].SetActive(false);
            }
        }

        if (count >= 8*BubbleLength)
        {
            RecipeManager.ReciManager.MakeOrder();
            this.gameObject.SetActive(false);
            return;
        }
    }
}
