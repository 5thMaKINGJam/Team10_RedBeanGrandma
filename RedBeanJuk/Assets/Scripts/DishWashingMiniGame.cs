using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWashingMiniGame : MonoBehaviour
{
    // [SerializeField] private GameObject SpaceBar;

    private int count = 0;

    // [SerializeField] private Canvas canvas;
    
    public GameObject[] Bubbles;
    public GameObject AlertPanel;
    
    

     private void Start() {
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
        
        
        if (true) 
        {
            // SpaceBar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
            }

            for (int i=0; i<Bubbles.Length; i++) {
                if (count == 6 * (i+1)) {
                    Bubbles[i].SetActive(false);
                }
            }

            if (count >= 25)
            {
                // SpaceBar.SetActive(false);
                // canvas.enabled = false;
            }
        }
    }
    
}
