using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private GameObject _audioManager;
    private void Start()
    {
        Time.timeScale = 1f;
        _audioManager = GameObject.FindWithTag("AudioManager");
        // _audioManager.GetComponent<AudioManager>().playSound("ButtonClick");
    }

    public void StartGame()
    {
        _audioManager.GetComponent<AudioManager>().playSound("ButtonClick");
        SceneManager.LoadScene(2);
    }
    
    public void StartCredits()
    {
        _audioManager.GetComponent<AudioManager>().playSound("ButtonClick");
        SceneManager.LoadScene(4);
    }
    
    
    public void Quit()
    {
        _audioManager.GetComponent<AudioManager>().playSound("ButtonClick");
        Application.Quit();
    }
}
