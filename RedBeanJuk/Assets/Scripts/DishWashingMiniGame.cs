using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWashingMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject SpaceBar;

    private int count = 0;

    [SerializeField] private Canvas canvas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpaceBar.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (true) 
        {
            SpaceBar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
            }

            if (count >= 25)
            {
                SpaceBar.SetActive(false);
                canvas.enabled = false;
            }
        }
    }
    
}
