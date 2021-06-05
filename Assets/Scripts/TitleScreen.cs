//Code taken from: https://www.youtube.com/watch?v=zc8ac_qUXQY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
       public void PlayGame ()
    { 
        FindObjectOfType<AudioManager>().Play("Select");
        AudioManager.instance.Stop("Title Screen Music");
        AudioManager.instance.Play("Menu Music");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

}
