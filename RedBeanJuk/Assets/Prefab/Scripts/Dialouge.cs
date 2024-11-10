using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dialouge : MonoBehaviour
{
    [SerializeField] private GameObject[] goodComms;

    [SerializeField] private GameObject[] badComms;
    private int index = 0;

    private void Awake()
    {
        index = Random.Range(0, 4);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (true /*made the right recipe*/)
        {
            goodComms[index].SetActive(true);
            Wait();
            goodComms[index].SetActive(false);
            
        }
        else
        {
            badComms[index].SetActive(true);
            Wait();
            badComms[index].SetActive(false);
        }
        index = Random.Range(0, 4);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
