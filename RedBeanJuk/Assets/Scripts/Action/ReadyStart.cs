using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class ReadyStart : MonoBehaviour
{
    public GameObject startimg;
    public GameObject readyimg;
    public GameObject blurimg;

    // public Material[] mat = new Material[2];
    // private Image background;
    private void Start()
    {
        // background = GetComponent<Image>();
        StartCoroutine(LoadGame());
    }
    
    private IEnumerator LoadGame() {
        readyimg.SetActive(true);
        blurimg.SetActive(true);
        // background.material = mat[0];

        yield return new WaitForSeconds(2f);
        startimg.SetActive(true);

        yield return new WaitForSeconds(1f);
        startimg.SetActive(false);
        readyimg.SetActive(false);
        blurimg.SetActive(false);
        // background.material = mat[1];
    }
}