using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    AudioMixerGroup audioMixerGroup;
    [Tooltip("This is the name of the controller that will be used to get the proper audio mixer group.  The controller should be a child of the 'Controllers' game object in the scene")]
    public string audioControllerName;
    private void Start()
    {
        audioMixerGroup = GameObject.Find("Controllers/" + audioControllerName).GetComponent<AudioSource>().outputAudioMixerGroup;
    }
    public void SetLevel(float sliderValue)
    {
        audioMixerGroup.audioMixer.SetFloat("MusicVolumeParameter", Mathf.Log10(sliderValue) * 20);
    }
}