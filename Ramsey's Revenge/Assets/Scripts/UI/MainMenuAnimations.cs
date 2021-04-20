using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnimations : MonoBehaviour
{
    public float duration;
    private Image image;
    [SerializeField] private Sprite[] sprites;
    private int index = 0;
    private float timer = 0;

    private void Start()
    {
        image = GetComponent<Image>();
        if (GameMusic.isMenuMusic != true)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().PlayMenuMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((timer+=Time.deltaTime) >= (duration / sprites.Length))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }
    }
}
