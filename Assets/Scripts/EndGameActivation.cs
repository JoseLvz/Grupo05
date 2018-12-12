using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGameActivation : MonoBehaviour {

    public Nave nave;
    public Image Transition;

    int levelToUnlock;

    void Start()
    {
        nave = FindObjectOfType<Nave>();
        levelToUnlock = SceneManager.GetActiveScene().buildIndex;
        
        
}

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("nonPlayer")){
            PlayerPrefs.SetInt("levelDoned", levelToUnlock);
            Debug.Log("i'm on " + levelToUnlock);
            nave.endGame = true;
            StartCoroutine(NextLevel());
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


    void FadeIn()
    {
        Transition.CrossFadeAlpha(1.0f, 1.5f, false);
    }
}
