using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Level_Transition : MonoBehaviour {

    public Image Transition;
    

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
}
