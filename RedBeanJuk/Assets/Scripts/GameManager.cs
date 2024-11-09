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
        
        
        if (currentTime >= StageTime)
        {
            //count how many bowls of juk player made
            if ( true/*bowl score >= 10*/)
            {
                Debug.Log("Level Success!");
                GameClear = true;
                //go to next scene
                LoadNextScene();
            }
            else
            {
                Debug.Log("Level Fail!");
                // go to bad ending
                GameClear = false;
            }
        }
    }

    void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DY");
        /*int nextSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;

        if (currentStage < 5)
        {
            currentStage++;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            //if player succeed in clearing the game, load good ending
            if (GameClear == true)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("");
            }
            //if player fail to clear the game, load bad ending
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("");

        }
        */
    }
    void StartStage()
    {
        currentTime = 0f;
        Debug.Log("Stage" + currentStage + "start");
    }
}
