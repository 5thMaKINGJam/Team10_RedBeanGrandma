using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
    [SerializeField] BackgroundColor background;
    public void StopTime(bool isStop)
    { 
        timeTicker.StopTimer(isStop);
    }

    #region Bowl Score
    private int bowlScore = 0;

    public int IncreaseBowl()
    {
        bowlScore++;
        return bowlScore;
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
    private bool isDone = false;
    public void EndStage(bool isSuccess)
    {
        StopTime(true);

        if (!isDone)
        {
            isDone = true;
            if (isSuccess)
            {
                Debug.Log("Level Success!");
                currentStage++;
                GameClear = true;
                if (currentStage < 6)
                {
                    background.ChangeBG(currentStage);
                    StartCoroutine(WaitAndReloadScene(2f));
                }
                else
                {
                    LoadEndingScene();
                }
            }
            else
            {
                Debug.Log("Level Fail!");
                GameClear = false;
                LoadBadEndingScene();
            }
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

    void LoadBadEndingScene()
    {
        currentStage = 1;
        SceneManager.LoadScene("_4Ending");
    }
    void LoadEndingScene()
    {
        currentStage = 1;
        SceneManager.LoadScene("_3Ending");
    }

    void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    #endregion

    private string sceneName;

    
}
