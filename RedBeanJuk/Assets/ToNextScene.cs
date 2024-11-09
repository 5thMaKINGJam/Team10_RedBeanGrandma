using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    [SerializeField] private float delay = 10f;
    
    private string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    public fadeScript FadeScript;

    //private bool goodEnding = GameManager.Instance.success();
    bool goodEnding = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (sceneName == "EndingScene2")
        {
            if (goodEnding == true)
            {
                nextSceneName = "_3GoodEnding";
            }
            else
            {
                nextSceneName = "_4BadEnding";
            }
        }
        FadeScript.Fade(true, delay-1.5f);
        Invoke("LoadNextScene", delay);
    }

    void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
