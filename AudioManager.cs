using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<AudioController> audioControllers;


    private void Awake()
    {
        SingletonPattern();
        foreach (AudioController controller in audioControllers)
        {
            controller.Source = gameObject.AddComponent<AudioSource>();
        }
        PlaySound(SoundEffects.Theme);
    }

    public void PlaySound(SoundEffects effect)
    {
        AudioController controller = GetControllerByEffect(effect);
        controller.PlaySound();
    }

    public void PlaySoundOnObject(SoundEffects effect, GameObject objectToPlay)
    {
        AudioController controller = GetControllerByEffect(effect);

        AudioSource sourceToPlay = GetSourceToPlay(objectToPlay);
        controller.Source = sourceToPlay;
        controller.PlaySound();

    }

    private static AudioSource GetSourceToPlay(GameObject objectToPlay)
    {
        return objectToPlay.GetComponent<AudioSource>() ? objectToPlay.GetComponent<AudioSource>() : objectToPlay.AddComponent<AudioSource>();
    }

    public void StopAllSounds()
    {
        foreach (AudioController controller in audioControllers)
        {
            controller.StopSound();
        }
    }


    private AudioController GetControllerByEffect(SoundEffects effect)
    {
        return audioControllers.Find(controller => controller.Effect == effect);
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