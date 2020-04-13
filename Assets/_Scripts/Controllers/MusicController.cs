using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls music playback
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    /// <summary>
    /// All songs in the Resources/Music folder at runtime
    /// </summary>
    List<Song> allSongs     = new List<Song>();
    /// <summary>
    /// All songs marked as enabled in the Resources/Music folder at runtime
    /// </summary>
    List<Song> activeSongs  = new List<Song>();
    ///#IGNORE
    void Start()
    {
        LoadAudioClips();
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
}
