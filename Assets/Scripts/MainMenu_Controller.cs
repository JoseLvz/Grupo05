using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Controller : MonoBehaviour {

    public Image Transition;

    private void Start()
    {
        Transition.canvasRenderer.SetAlpha(0.0f);
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
        Transition.CrossFadeAlpha(1.0f, 1.5f, true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
