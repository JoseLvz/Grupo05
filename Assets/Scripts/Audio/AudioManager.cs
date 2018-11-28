using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Audio_Modelo[] Sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Audio_Modelo Audio in Sounds)
        {
            Audio.source = gameObject.AddComponent<AudioSource>();

            Audio.source.clip = Audio.clip;
            Audio.source.volume = Audio.volume;
            Audio.source.pitch = Audio.speed;
            Audio.source.spatialBlend = Audio.Space3D;
            Audio.source.dopplerLevel = Audio.Distancia_Rango;
            Audio.source.loop = Audio.loop;
            Audio.source.spread = Audio.Spread;
        }
    }

    public void Play(string name)
    {
        Audio_Modelo Audio = Array.Find(Sounds, sound => sound.Name == name);
        Audio.source.Play();
    }
}
