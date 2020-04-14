using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Controls audio playback sans music
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    ///#IGNORE
    AudioSource audioSource;
    /// <summary>
    /// The AudioMixerGroup that this controller uses to route clip output.  
    /// </summary>
    public AudioMixerGroup audioMixerGroup;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioMixerGroup = audioSource.outputAudioMixerGroup;
    }
    /// #IGNORE
    void OnEnable()
    {

    }
}
