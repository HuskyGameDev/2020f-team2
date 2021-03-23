using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void changeMenuScene(string scene)
    {
        SceneManager.LoadScene(scene);
        SceneManager.UnloadSceneAsync("Menu Scene");
    }

    public void exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
