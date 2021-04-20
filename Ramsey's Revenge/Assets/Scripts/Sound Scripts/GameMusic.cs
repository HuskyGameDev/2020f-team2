using System;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource MenuMusic;
    public AudioSource LevelMusic;

    private static GameMusic instance;

    static public Boolean isMenuMusic;
    static public Boolean isLevelMusic;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    public void PlayMenuMusic()
    {
        MenuMusic.loop = true;
        isMenuMusic = true;
        isLevelMusic = false;
        StopMusic();
        MenuMusic.Play();
    }
    public void PlayLevelMusic()
    {
        LevelMusic.loop = true;
        isMenuMusic = false;
        isLevelMusic = true;
        StopMusic();
        LevelMusic.Play();
    }

    public void StopMusic()
    {
        MenuMusic.Stop();
        LevelMusic.Stop();
    }
}
