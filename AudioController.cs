using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioController
{
    public SoundEffects Effect;

    [Range(0f, 1f)]
    public float volume;

    public AudioClip Clip;

    public bool Loop;

    [Range(0f, 1f)]
    public float SpatialBlend;

    [Range(0f, 500f)]
    public float maxDistance = 100f;
    public bool Pitchvariation;

    [HideInInspector]
    public AudioSource Source;

    private readonly float LowPitchRange = .95f;
    private readonly float HighPitchRange = 1.05f;


    public void PlaySound()
    {
        Source.clip = Clip;
        if (Pitchvariation)
        {
            Source.pitch = GetRandomPitch();
        }
        Source.loop = Loop;
        Source.volume = volume;
        Source.spatialBlend = SpatialBlend;
        Source.maxDistance = maxDistance;
        Source.Play();
    }

    public void StopSound()
    {
        Source.Stop();
    }

    private float GetRandomPitch()
    {
        return Random.Range(LowPitchRange, HighPitchRange);
    }
}