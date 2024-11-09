using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject[] backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        DeactivateBackground();
        backgrounds[0].SetActive(true);
    }

    private void DeactivateBackground()
    { 
        foreach (GameObject bg in backgrounds)
        {
            bg.SetActive(false);
        }
    }
    
    public void ActivateBackground(int index)
    {
        if (index >= 0 && index < backgrounds.Length)
        {
            DeactivateBackground();
            backgrounds[index-1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int currentStage = GameManager.Instance.GetStage();
        ActivateBackground(currentStage);
    }
}
