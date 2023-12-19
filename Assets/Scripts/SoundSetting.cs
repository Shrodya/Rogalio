using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    
    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Update()
    {
        audioSrc.volume = musicVolume;
    } 
}
