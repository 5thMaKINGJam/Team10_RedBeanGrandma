using System.Collections;
using UnityEngine;

public class Gompang : MonoBehaviour
{
    public GameObject AlertMsg;
    public GameObject[] Gompangs;

    public GameObject bad;
    public GameObject ending;
    private KeyCode[] keys = new KeyCode[] {
        KeyCode.G, KeyCode.F, KeyCode.D, KeyCode.F, KeyCode.A, KeyCode.F, KeyCode.C, KeyCode.F
    };
    public GameObject[] Hints;
    public GameObject HintSet;
    private int index = 0;
    private void Start() {
        StartCoroutine(Alertmsg());
    }
    private IEnumerator Alertmsg()
    {
        AlertMsg.SetActive(true);
        yield return new WaitForSeconds(1f);
        AlertMsg.SetActive(false);
    }
    
    private void Update() {
        if (index < Gompangs.Length) {
            if (Input.GetKeyDown(keys[index])) {
                Gompangs[index].SetActive(false);
                Hints[index].SetActive(false);
                index++;
            }
        }

        if (index >= Gompangs.Length){
            StartCoroutine(last());
        }       
    }

    private IEnumerator last()
    { 
        yield return new WaitForSeconds(1.5f);
        bad.SetActive(false);
        ending.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
