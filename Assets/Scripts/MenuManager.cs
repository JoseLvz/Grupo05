﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject DefeatMenuUI;
    public static bool gameIsPaused = false;
    public GameObject PauseUI;
    Nave nave;
    public GameObject Ranking, nameDialog;
    public HighScoreManager scoreManager;
    private static int lastScore;

    private void Awake()
    {
       
    }

    void Start()
    {
        nave = GameObject.FindWithTag("Player").GetComponent<Nave>();
        scoreManager = GameObject.FindWithTag("scorem").GetComponent<HighScoreManager>();
    }

    void Update()
    {
        if (nave.isDead == true){
            DefeatMenuUI.SetActive(true);
            scoreManager.isOver = true;
        }
        if(gameIsPaused==true)
            {
            scoreManager.isOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !nave.isDead)
        {
            if (!gameIsPaused)
            {
               
                Pause();
            }
            else
            {
                Resume();

            }
        }

    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("PauseSFX");
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        AudioListener.pause = false;
        //PauseOFF();
        /*FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().Play("Motor");*/

    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("PauseSFX");
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioListener.pause = true;
        //PauseON();


        /*FindObjectOfType<AudioManager>().Play("PauseSFX");
        FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().StopVFX("Motor");*/
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        Score.myScore = 0 + lastScore;
        FindObjectOfType<AudioManager>().Play("Motor");
    }

    public void BackToMenu(){
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().StopVFX("Motor");

    }

    public static void SetScore()
    {
        lastScore = Score.myScore;
    }
    
    public void EnterScore()
    {
        Ranking.SetActive(true);
        nameDialog.SetActive(true);
        DefeatMenuUI.SetActive(false);
    }


    /*void PauseON(){
        StartCoroutine(PauseAwake());
    }

    void PauseOFF()
    {
        StartCoroutine(PauseAwakeResume());
    }

    IEnumerator PauseAwake()
    {
        yield return new WaitForSeconds(0.7f);
        AudioListener.pause = true;
    }

    IEnumerator PauseAwakeResume()
    {
        yield return new WaitForSeconds(0.7f);
        AudioListener.pause = false;
    }*/



    /*public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }*/

}

