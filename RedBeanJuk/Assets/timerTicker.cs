using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class timerTicker : MonoBehaviour
{
    public Slider timerSlider;
    public GameObject fill;
    public float sliderTimer = 60.00f;
    [SerializeField] bool stopTimer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();
    }

    public void StartTimer()
    {
        fill.SetActive(true);
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                EndStage();
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer;
            }
        }
    }

    private void EndStage()
    {
        fill.SetActive(false);
        GameManager.Instance.EndStage(false);
    }
    public void StopTimer()
    {
        stopTimer = true;
    }
}


