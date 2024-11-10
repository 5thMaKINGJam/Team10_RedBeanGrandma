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
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            count++;
            foreach (var bubble in Bubbles)
                bubble.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            //Bubbles���� KeyDown�� ���� scale 1.2�� Ŀ����, KeyUp�� ���� ���ÿ��� scale 1��
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            foreach (var bubble in Bubbles)
                bubble.transform.localScale = Vector3.one; // ��ǰ ũ�� ������� (1��)
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
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        RecipeManager.ReciManager.MakeOrder();
    }
}
