using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    int sceneIndex;
    int requirement = 5;
    public Image transition;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(requirement == sceneIndex)
        {
            FindObjectOfType<AudioManager>().StopVFX("Motor");
            StartCoroutine(MenuAwake());
        }
    }

    void BackToMenu()
    {

    }

    IEnumerator MenuAwake()
    {
        yield return new WaitForSeconds(70f);
        FadeIn();
        FindObjectOfType<AudioManager>().Pause();
        SceneManager.LoadScene("Menu");

    }

    void FadeIn()
    {
        transition.CrossFadeAlpha(1.0f, 1.5f, false);
    }

}
