using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gompang : MonoBehaviour
{
    public GameObject AlertMsg;
    public GameObject[] Gompangs;
    private KeyCode[] keys = new KeyCode[] {
        KeyCode.G, KeyCode.F, KeyCode.D, KeyCode.F, KeyCode.A, KeyCode.F, KeyCode.C, KeyCode.F
    };
    private int index = 0;
    private void Start() {
        StartCoroutine(Alertmsg());
    }
    private IEnumerator Alertmsg()
    {
        AlertMsg.SetActive(true);
        yield return new WaitForSeconds(2f);
        AlertMsg.SetActive(false);
    }
    
    private void Update() {
        if (index < Gompangs.Length) {
            if (Input.GetKeyDown(keys[index])) {
                Gompangs[index].SetActive(false);
                index++;
            }
        }
        if (index == 7) {
            
        }
    }

}
