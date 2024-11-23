using UnityEngine;

[CreateAssetMenu(fileName ="MusicContainer",menuName = "MusicContainer",order = 0)]
public class MusicContainer : ScriptableObject
{
    public string LevelName;
    public AudioClip Music;
    [Range(0, 1)]
    public float Volume = 1.0f;
}
