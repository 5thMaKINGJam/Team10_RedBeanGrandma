using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playMusic : MonoBehaviour
{
    
    private string sceneName;
    
    void BGM()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "_1FirstScene" || sceneName == "_1-2Story" || sceneName == "_2GameScene")
        {
            AudioManager.instance.PlayBGM(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        BGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
