using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Transition : MonoBehaviour {

    public Image Transition;
    public Animator anim;

    

    IEnumerator Start()
    {
        Transition.canvasRenderer.SetAlpha(0.9f);

        //FadeIn();
        yield return new WaitForSeconds(1f);
        FadeOut();
    }
	
    void FadeIn()
    {
        Transition.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void FadeOut()
    {
        Transition.CrossFadeAlpha(0.0f, 1.5f, false);
    }

    public void StartAnim()
    {
        anim.SetBool("Credits", true);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Pause();
        FindObjectOfType<AudioManager>().StopVFX("Motor");

    }

}
