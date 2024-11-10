using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    [SerializeField] private GameObject[] stageColor;

    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gO in stageColor)
        {
            gO.SetActive(false);
        }
        stageColor[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        index = GameManager.Instance.GetStage();
        while (index >= 2)
        {
            stageColor[index-1].SetActive(true);
            stageColor[index-2].SetActive(false);
        }
    }
}
