using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Controls music playback
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    /// <summary>
    /// Song scriptable object of the currently playing audio clip
    /// </summary>
    public Song currentSong;
    /// <summary>
    /// Amount of time to wait between end of currentSong and start of next song
    /// </summary>
    public float delayBetweenSongs = 0;
    /// <summary>
    /// All songs in the Resources/Music folder at runtime
    /// </summary>
    List<Song> allSongs     = new List<Song>();
    /// <summary>
    /// All songs marked as enabled in the Resources/Music folder at runtime
    /// </summary>
    List<Song> activeSongs  = new List<Song>();
    ///#IGNORE
    ///
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
        LoadAudioClips();
        PlayRandomMusicAudioClip();
    }
    /// <summary>
    /// Loads the Song scriptable objects present in the Resources/Music folder at runtime 
    /// </summary>
    void LoadAudioClips()
    {
        Song[] clips = Resources.LoadAll<Song>("Music");
        foreach (Song clip in clips)
        {
            allSongs.Add(clip);
            if (clip.enabled)
                activeSongs.Add(clip);
        }
    }
    /// <summary>
    /// Select a song from the activeSongs list and play it, recursively invokes to start a new song when clip finishes + delayBetweenSongs value
    /// </summary>
    private void PlayRandomMusicAudioClip()
    {
        currentSong = activeSongs[UnityEngine.Random.Range(0, activeSongs.Count)];
        audioSource.clip = currentSong.song;
        audioSource.Play();
        Invoke("PlayRandomMusicAudioClip", (float)currentSong.playTime + delayBetweenSongs);
    }
}
