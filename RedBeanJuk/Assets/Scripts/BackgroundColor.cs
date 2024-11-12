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

    public void ChangeBG(int idx)
    {
        if (index >= 2)
        { 
            stageColor[index -2].SetActive(false);
            stageColor[index - 1].SetActive(true);
        }
    }
}
