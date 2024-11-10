using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scoreLimit = 10;
    #region Singleton
    public static GameManager Instance;
    private LevelManager levelManager;

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

        levelManager = this.GetComponent<LevelManager>();
    }
    #endregion

    #region SceneLoad Check
    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded" + scene.name);
        Debug.Log("Load mode" + mode);

        levelManager.StartStage(currentStage);
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    #endregion

    [SerializeField] timerTicker timeTicker;
    public void StopTime()
    { 
        timeTicker.StopTimer();
    }


    #region Bowl Score
    private int bowlScore = 0;

    public void IncreaseBowl()
    {
        bowlScore++;
        Debug.Log($"bowlScore : {bowlScore}");
        if (bowlScore == scoreLimit)
        {
            levelManager.KeyBoard();
        }
        else if (bowlScore == (int)scoreLimit / 2)
        { 
            levelManager.DishWash();
        }
    }

    public int BowlScore()
    {
        return bowlScore;
    }
    #endregion

    private static int currentStage = 1;

    public int GetStage()
    {
        return currentStage;
    }

    private bool GameClear = false;

    public void EndStage(bool isSuccess)
    {
        if (isSuccess)
        {
            Debug.Log("Level Success!");
            currentStage++;
            GameClear = true;
            if (currentStage < 6)
            {
                StartCoroutine(WaitAndReloadScene(2f));
            }
        }
        else
        {
            Debug.Log("Level Fail!");
            GameClear = false;
            LoadEndingScene();
        }
    }

    public bool GetSuccessOrNot()
    {
        return GameClear;
    }

    [SerializeField] GameObject startPanel;
    #region loadingScene

    IEnumerator WaitAndReloadScene(float waitTime)
    {
        startPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }

    public void LoadSuccessEnding()
    {
        GameClear = true;
        LoadEndingScene();
    }

    void LoadEndingScene()
    {
        Debug.Log($"LoadEndingScene {currentStage}");
        SceneManager.LoadScene("_3Ending");
    }

    void LoadNextScene()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }
    #endregion
}
