//Code taken from: https://www.youtube.com/watch?v=YOaYQrN1oYQ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
This class sets the volume slider and volume in the options menu to whatever the volume is at. 
*/
public class OptionsMenu : MonoBehaviour
{    
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
