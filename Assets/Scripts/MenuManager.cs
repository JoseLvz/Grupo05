using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject DefeatMenuUI;
    public static bool gameIsPaused = false;
    public GameObject PauseUI;
    Nave nave;

    void Start()
    {
        nave = GameObject.FindWithTag("Player").GetComponent<Nave>();
    }

    void Update()
    {
        //Lo que hace aparecer el menu
        if (nave.isDead == true){
            DefeatMenuUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;


        FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().Play("Motor");

    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        FindObjectOfType<AudioManager>().Play("PauseSFX");
        FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().StopVFX("Motor");
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu(){
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().StopVFX("Motor");

    }


    /*public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }*/

}

