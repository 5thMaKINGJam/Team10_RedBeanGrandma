using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastGameController : MonoBehaviour
{
    public GameObject firstGame;
    public GameObject secondGame;
    public GameObject thirdGame;

    private void Awake()
    {
        firstGame.SetActive(false);
        secondGame.SetActive(false); 
        thirdGame.SetActive(false);
    }

    private void Start()
    {
        firstGame.SetActive(true);
    }
}
