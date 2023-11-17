using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    
    public void Quit()
    {
        Application.Quit();
    }
}
