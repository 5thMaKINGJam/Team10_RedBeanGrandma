using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader_tuto2 : MonoBehaviour
{
    public void LoadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_2GameScene");
    }
}
