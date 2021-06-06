//Code taken from: https://www.youtube.com/watch?v=6OT43pvUyfY

using UnityEngine.Audio;
using System;
using UnityEngine;

/**
This class manages all audio files such as music and sound effects. When called it can 
stop or play an audio clip. When the game starts it automatically plays the "Title
Screen Music".
*/
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    /**This method allows me to adjust the audio clips with various aspects of sounds
    such as volume, pitch, and whether or not the audio clip loops.
    */
    void Awake()
    {
        if (instance == null)
        instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;

        }
    }

    void Start ()
    {
        Play("Title Screen Music");
    }

    //This method plays an audio clip when called
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //If the audio clip does not exist
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }
        s.source.Play();
    }

    //This method stops an audio clip that is playing when called
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null)
        {
            return;
        }
    }

}
