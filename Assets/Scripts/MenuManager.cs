using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject DefeatMenuUI;
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

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }

    /*public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }*/

}

