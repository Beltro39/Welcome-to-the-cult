using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene("Login");
    }

    public void loadTutorial()
    {
        Application.OpenURL("https://www.google.com");
    }

    
}

