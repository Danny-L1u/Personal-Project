//Code taken from: https://www.youtube.com/watch?v=6OT43pvUyfY

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

/**
This class allows me to input sound clips through Unity. Then once inputed I can call on them
in other scripts so they can be played.
*/
public class Sound 
{
    public string name;

    public AudioClip clip;
    public AudioMixerGroup group; 

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    public bool loop;
    [HideInInspector]
    public AudioSource source;

}
