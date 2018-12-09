using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public static LevelController instace = null;

    public Image Transition;

    int index, level;

    void Start()
    {

        if(instace == null)
        {
            instace = this;
        }else if(instace != this)
        {
            Destroy(gameObject);
        }

    }

    IEnumerator NextLevel()
    {
        Transition.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //FadeOut();
    }

    IEnumerator CreditsAwake()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Credits");
        yield return new WaitForSeconds(15f);
        Transition.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        SceneManager.LoadScene("Menu");
    }

    void FadeIn()
    {
        Transition.CrossFadeAlpha(1.0f, 1.5f, false);
    }
}
