using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int bowlScore = 0;
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

    private int currentStage = 1;
    private bool GameClear = false;

    private bool miniGameTime = false;

    public bool MiniGameTime()
    {
        return miniGameTime;
    }
    
    public int GetStage()
    {
        return currentStage;
    }

    public void EndStage()
    {
        if (bowlScore >= 10)
        {
            Debug.Log("Level Success!");
            currentStage++;
            GameClear = true;
            StartCoroutine(WaitAndReloadScene(3f));
        }
        else
        {
            Debug.Log("Level Fail!");
            GameClear = false;
        }
        LoadNextScene();
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("_3GoodEnding");
            }
            //if player fail to clear the game, load bad ending
            else if (GameClear == false)
            { 
                UnityEngine.SceneManagement.SceneManager.LoadScene("_4BadEnding");
            }
    }

    void ReloadScene()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }

    public void IncreaseBowl()
    {
        bowlScore++;
        Debug.Log($"bowlScore : {bowlScore}");
    }

    public int BowlScore()
    {
        return bowlScore;
    }
}
