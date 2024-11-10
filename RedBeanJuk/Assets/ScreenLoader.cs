using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    public void LoadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial_ing");
    }
}
