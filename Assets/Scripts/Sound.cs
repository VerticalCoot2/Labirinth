using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sound
{

    public string name;
    public int index;
    public AudioClip clip;
    [Range(0,100)] public float volume = 1;
    [Range(-3,3)] public float pitch = 1;
    [Range(-1,1)]public float stereoPan = 0;
    [Range(0,1)] public float spatialBlend = 0;
    [Range(0,1.2f)] public float reverbZoneMix = 1;

    public bool loop = false;

    [HideInInspector] public AudioSource source;
}
