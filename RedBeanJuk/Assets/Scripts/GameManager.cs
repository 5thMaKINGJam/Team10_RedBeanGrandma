using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded" + scene.name);
        Debug.Log("Load mode" + mode);
        
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private float StageTime = 60f;
    private float currentTime = 0f;
    private int currentStage = 1;
    private bool GameClear = false;
    

    private void Start()
    {
        StartStage();
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        
        
        // if (currentTime >= StageTime )
        // {
        //     //count how many bowls of juk player made
        //     if ( bowlscore >= 10)
        //     {
        //         Debug.Log("Level Success!");
        //         currentStage++;
        //         StartCoroutine(WaitAndReloadScene(3f));
        //     }
        //     else
        //     {
        //         Debug.Log("Level Fail!");
        //         // go to bad ending
        //         GameClear = false;
        //         LoadNextScene();
        //     }
        // }
    }

    IEnumerator WaitAndReloadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ReloadScene();
    }

    void LoadNextScene()
    {
        //if player succeed in clearing the game, load good ending
            if (GameClear == true && currentStage == 5 )
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("");
            }
            //if player fail to clear the game, load bad ending
            else if (GameClear == false)
            { 
                UnityEngine.SceneManagement.SceneManager.LoadScene("");
            }
    }
    void StartStage()
    {
        currentTime = 0f;
        Debug.Log("Stage" + currentStage + "start");
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        StartStage();
        
    }
}
