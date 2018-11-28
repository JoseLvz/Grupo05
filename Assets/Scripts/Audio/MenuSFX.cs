using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour {

    public AudioSource mySFX;
    public AudioClip hover;
    public AudioClip click;

    public void Button_HoverSound()
    {
        mySFX.PlayOneShot(hover);
    }

    public void Button_ClickSound()
    {
        mySFX.PlayOneShot(click);
    }
}
