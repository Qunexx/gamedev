using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PauseGame;
    public GameObject PauseGameMenu;

    // Update is called once per frame
    void Update()
    { if(Input.GetKeyDown(KeyCode.Escape)){
        if(PauseGame)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        }
    }


public void Resume()
{
    PauseGameMenu.SetActive(false);
    Time.timeScale = 1f;
    PauseGame = false;
}

public void Pause()
{
    PauseGameMenu.SetActive(true);
    Time.timeScale = 0f;
    PauseGame = true;
}

public void LoadMenu()

{

    Time.timeScale = 1f;
    SceneManager.LoadSceneAsync("menu");
}

}