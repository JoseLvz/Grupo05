using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio_Modelo {

    public string Name;

    public AudioClip clip;



    [Range (0f,1f)]
    public float volume;
    [Range(-3f,3f)]
    public float speed;
    [Range(0f, 1f)]
    public float Space3D;
    [Range(0f, 5f)]
    public float Distancia_Rango;
    [Range(0f, 600f)]
    public float MaxRango;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
