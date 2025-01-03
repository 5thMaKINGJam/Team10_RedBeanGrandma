using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class fadeScript : MonoBehaviour
{
    
    
    public Image Panel;
    private float time = 0f;
    private float F_time = 1f;
    
    
    public void Fade(bool Bool = false, float delay = 0)
    {
        StartCoroutine(FadeWithDelay(Bool, delay));
        
    }

    private IEnumerator FadeWithDelay(bool Bool, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (Bool == true)
        {
            StartCoroutine(FadeFlow());
        }
        
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(0.5f);
        
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
