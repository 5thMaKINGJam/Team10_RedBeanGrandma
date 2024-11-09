using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWashingMiniGame : MonoBehaviour
{
    private bool StageFour = false;

    private int currentStage = GameManager.Instance.GetStage();

    private int bowlScore = GameManager.Instance.BowlScore();

    [SerializeField] private GameObject SpaceBar;

    private int count = 0;

    private bool miniGameTime = GameManager.Instance.MiniGameTime();
    
    // Start is called before the first frame update
    void Start()
    {
        SpaceBar.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (currentStage == 4)
        {
            StageFour = true;
            if (bowlScore == 5)
            {
                miniGameTime = true;
            }
        }


        if (miniGameTime == true) 
        {
            SpaceBar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
            }

            if (count >= 25)
            {
                SpaceBar.SetActive(false);
                miniGameTime = false;
            }
        }
        
    }
}
