using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Audio_Modelo[] Sounds;



    [HideInInspector]
    public AudioSource source2;

    public AudioClip[] music;

    [Range(0,1)]
    public float volume;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);



        foreach (Audio_Modelo Audio in Sounds)
        {
            Audio.source = gameObject.AddComponent<AudioSource>();

            Audio.source.clip = Audio.clip;
            Audio.source.volume = Audio.volume;
            Audio.source.pitch = Audio.speed;
            Audio.source.spatialBlend = Audio.Space3D;
            Audio.source.dopplerLevel = Audio.Distancia_Rango;
            Audio.source.loop = Audio.loop;


        }

        source2 = gameObject.AddComponent<AudioSource>();
        source2.volume = volume;


    }



    public void Play(string name)
    {
        Audio_Modelo Audio = Array.Find(Sounds, sound => sound.Name == name);
        Audio.source.Play();
    }

    public void StopVFX(string name)
    {
        Audio_Modelo Audio = Array.Find(Sounds, sound => sound.Name == name);
        Audio.source.Pause();
    }


    public void PlaySong()
    {
        // Audio_Modelo Audio = Array.Find(Sounds, sound => sound.Name == name);
        source2.clip = music[UnityEngine.Random.Range(0, music.Length)];
        source2.Play();
    }

    public void Pause()
    {
        if (source2.isPlaying)
            source2.Pause();
        else
            source2.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){
            PlaySong();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

}
