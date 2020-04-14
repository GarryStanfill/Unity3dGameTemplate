using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Sets the volume of AudioMixerGroup from slider range 0.0001 - 1.  Put class on slider.
/// </summary>
[RequireComponent(typeof(Slider))]
public class SetVolume : MonoBehaviour
{
    AudioMixerGroup audioMixerGroup;
    [Tooltip("This is the name of the controller that will be used to get the proper audio mixer group.  The controller should be a child of the 'Controllers' game object in the scene")]
    public string audioControllerName;
    ///#IGNORE
    Slider slider;
    ///#IGNORE
    private void Start()
    {
        audioMixerGroup = GameObject.Find("Controllers/" + audioControllerName).GetComponent<AudioSource>().outputAudioMixerGroup;
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(audioControllerName + "-Volume", 0.75f); // must be set to some value between 0.0001 - 1
    }
    /// <summary>
    /// Sets the volume level in decibels (-80 - 0) on the slider
    /// </summary>
    /// <param name="sliderValue">value from slider</param>
    public void SetLevel(float sliderValue)
    {
        audioMixerGroup.audioMixer.SetFloat("MusicVolumeParameter", Mathf.Log10(sliderValue) * 20);
        SaveLevel(sliderValue);
    }
    /// <summary>
    /// Save the level to PlayerPrefs
    /// </summary>
    /// <param name="sliderValue">value of the slider</param>
    private void SaveLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat(audioControllerName + "-Volume", sliderValue);
    }
}