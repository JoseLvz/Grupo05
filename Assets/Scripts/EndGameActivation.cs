using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGameActivation : MonoBehaviour {

    public Nave nave;
    public Image Transition;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nonPlayer"))
        {
            nave.endGame= true;
            StartCoroutine(Level1());
        }
    }

    IEnumerator Level1()
    {
        Transition.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level1");
        //FadeOut();
    }

    void FadeIn()
    {
        Transition.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        Transition.CrossFadeAlpha(0.0f, 1.5f, false);
    }
}
