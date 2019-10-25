using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    //Reference to audio source
    private AudioSource audioSrc;

    //Music volume being modified
    //by dragging slider
    private float musicVolume = 1f;

    //Intiatization
    void Start()
    {
        //Assigning the audio
        audioSrc = GetComponent<AudioSource>();
    }
    //updating per frame of slider
    void Update()
    {
        //Setting volume
        audioSrc.volume = musicVolume;
    }
    //calls the slider adn paassing value to slider
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}