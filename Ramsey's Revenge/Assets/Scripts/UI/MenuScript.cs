using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void changeMenuScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if (GameMusic.isLevelMusic != true)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().StopMusic();
            GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().PlayLevelMusic();
        }
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
