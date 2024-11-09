using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        if (bowlScore == 1)
        {
            levelManager.KeyBoard();
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

    public void EndStage()
    {
        if (bowlScore >= 1)
        {
            Debug.Log("Level Success!");
            currentStage++;
            GameClear = true;
            if (currentStage < 5) {
                StartCoroutine(WaitAndReloadScene(3f));
            }
        }
        else
        {
            Debug.Log("Level Fail!");
            GameClear = false;
            LoadEndingScene();
        }
    }
    #region loadingScene

    IEnumerator WaitAndReloadScene(float waitTime)
    {
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
        //if player succeed in clearing the game, load good ending
            if (GameClear == true && currentStage >= 6 )
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("_3GoodEnding");
            }
            //if player fail to clear the game, load bad ending
            else if (GameClear == false)
            {
                //GameOver = true;
                //FadeScript.Fade(GameOver, 0f);
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene1");
            }
    }

    void LoadNextScene()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }
    #endregion
}
