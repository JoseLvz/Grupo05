using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Audio_Modelo Sounds;

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


        Sounds.source = gameObject.AddComponent<AudioSource>();

        Sounds.source.volume = Sounds.volume;
        Sounds.source.pitch = Sounds.speed;
        Sounds.source.spatialBlend = Sounds.Space3D;
        Sounds.source.dopplerLevel = Sounds.Distancia_Rango;
        Sounds.source.loop = Sounds.loop;
        Sounds.source.spread = Sounds.Spread;
      

    }

    public void Play()
    {
        // Audio_Modelo Audio = Array.Find(Sounds, sound => sound.Name == name);
        Sounds.source.clip = Sounds.clips[UnityEngine.Random.Range(0, Sounds.clips.Length)];
        Sounds.source.Play();
    }

    public void Pause() {
        if (Sounds.source.isPlaying)
            Sounds.source.Pause();
        else
            Sounds.source.Play();
    }
}
