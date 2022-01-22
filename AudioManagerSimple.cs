using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSimple : MonoBehaviour
{
    public static AudioManagerSimple instance;

    [SerializeField]
    private AudioClip gameThemeFile;
    private AudioSource gameTheme;


    private void Awake()
    {
        SingletonPattern();
        gameTheme = gameObject.AddComponent<AudioSource>();
        gameTheme.clip = gameThemeFile;
        gameTheme.loop = true;
        gameTheme.volume = .5f;
        gameTheme.Play();
    }


    private void SingletonPattern()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}