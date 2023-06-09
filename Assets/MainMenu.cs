using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    { 
        
        SceneManager.LoadSceneAsync("1lvl");


    }
    public void ExitGame()
    {
       
        Application.Quit();

    }
    
}
