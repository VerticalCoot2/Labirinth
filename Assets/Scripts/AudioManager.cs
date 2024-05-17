using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    //Random r = new Random();
    int sCount = 0;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume/100;
            s.source.pitch = s.pitch;
            s.source.panStereo = s.stereoPan;
            s.source.spatialBlend = s.spatialBlend;
            s.source.reverbZoneMix = s.reverbZoneMix;
            s.source.loop = s.loop;
            sCount++;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayScarryNoise()
    {
        int rand = UnityEngine.Random.Range(1, sCount);
        Sound s = Array.Find(sounds, sound => sound.index == rand);
        if (s == null)
        {
            Debug.LogWarning("Sound with index " + rand + " not found!");
            return;
        }
        int stereoRand = UnityEngine.Random.Range(1, 2);
        switch(stereoRand)
        {
            case 1:
                s.stereoPan = -1;
                break;
            case 2:
                s.stereoPan = 1;
                break;
        }
        
        s.source.Play();
    }
}//FindFirstObjectByType<AudioManager>().Play("");