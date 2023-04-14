using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text restartText;
    private bool isGameOver = false;


    void Start()
    {

        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G) && !isGameOver)
        {
            isGameOver = true;
            SceneManager.LoadSceneAsync("wasted");
            StartCoroutine(GameOverSequence());
        }


        if (isGameOver)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
        }


    }


    private IEnumerator GameOverSequence()
    {
        gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        restartText.gameObject.SetActive(true);
    }
}