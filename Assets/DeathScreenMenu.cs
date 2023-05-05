using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMenu : MonoBehaviour
{
    public void RestartGame() // перезапуск 1 лвла
    {
        SceneManager.LoadSceneAsync("1lvl");



    }



}
