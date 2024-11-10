using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsAndNext : MonoBehaviour
{
    public void goTo_1_2_storyScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_1-2Story");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
