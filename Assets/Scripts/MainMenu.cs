//Code Taken from: https://www.youtube.com/watch?v=zc8ac_qUXQY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    { 
        FindObjectOfType<AudioManager>().Play("Select");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        Application.Quit();
    }

}
