using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Controller : MonoBehaviour {

    public Image Transition;
    public Button button;


    void Start()
    {
        button.Select();
        FindObjectOfType<AudioManager>().Play("Theme");


    }

    public void LevelToLoad(int level)
    {
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioManager>().Play("Motor");
        FindObjectOfType<AudioManager>().StopVFX("Theme");
        FindObjectOfType<AudioManager>().PlaySong();
    }


    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        FindObjectOfType<AudioManager>().StopVFX("Theme");
        FindObjectOfType<AudioManager>().PlaySong();
    }

    IEnumerator ChangeEscene()
    {
        Transition.canvasRenderer.SetAlpha(0.0f);


        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().Play("Motor");
        FadeIn();


    }

    void FadeIn()
    {
        Transition.CrossFadeAlpha(1.0f, 1.5f, false);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
