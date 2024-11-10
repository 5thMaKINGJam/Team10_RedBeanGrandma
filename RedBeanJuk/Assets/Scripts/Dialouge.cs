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


    public void Comments(bool isBool)
    {
        index = Random.Range(0, 4);
        GameObject go;
        go = isBool ? goodComms[index] : badComms[index];
        StartCoroutine(Wait(go));

    }

    private IEnumerator Wait(GameObject go)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(1f);
        go.SetActive(false);
    }
}
