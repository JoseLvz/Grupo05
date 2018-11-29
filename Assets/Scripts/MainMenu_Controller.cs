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

    }


    public void PlayGame()
    {
        StartCoroutine(ChangeEscene());
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator ChangeEscene()
    {
        Transition.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       

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
