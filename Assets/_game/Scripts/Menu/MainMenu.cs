﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayLevelOne ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevelThree()
    {
        SceneManager.LoadScene("Level3");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
