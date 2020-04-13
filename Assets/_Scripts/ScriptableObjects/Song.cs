using UnityEngine;
/// <summary>
/// Song scriptable object
/// </summary>
[CreateAssetMenu(fileName = "Song", menuName = "New/Song")]
public class Song : ScriptableObject
{
    /// <summary>
    /// The name of the audio clip
    /// </summary>
    public string songName;
    /// <summary>
    /// Audioclip reference
    /// </summary>
    public AudioClip song;
    /// <summary>
    /// Length of the song.
    /// <remarks>Extrapolated when OnEnable executes</remarks>
    /// </summary>
    public double playTime;
    /// <summary>
    /// Is this song clip enabled?
    /// </summary>
    public bool enabled = true;
    ///#IGNORE
    private void OnEnable()
    {
        playTime = song.length;
    }
}
