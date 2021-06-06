//Code taken from: https://www.youtube.com/watch?v=zc8ac_qUXQY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/**
This class stops the current music if it is not done playing, then plays the menu music.
It also plays the select sound effect when the "START" button is played and loads into the 
next Unity scene.
*/
public class TitleScreen : MonoBehaviour
{
    public AudioMixer audioMixer;

    //When the game starts set the volume to a specific amount
    void Start(){
        audioMixer.SetFloat("Volume", 0f);
    }
    //When the "START" button is clicked
       public void PlayGame ()
    { 
        FindObjectOfType<AudioManager>().Play("Select");
        AudioManager.instance.Stop("Title Screen Music");
        AudioManager.instance.Play("Menu Music");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

}
