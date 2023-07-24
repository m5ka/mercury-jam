using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public AudioSource menuMusic;
    public float musicVolume = 0.2f;

    private void Start()
    {
        startButton.onClick.AddListener(TaskOnClick);
        menuMusic.volume = musicVolume;
        menuMusic.Play();
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
