//Code Taken from: https://www.youtube.com/watch?v=zc8ac_qUXQY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
This class manages the main menu, allowing the player to progress to the game when "PLAY" is clicked,
allowing the player to quit the game when "QUIT" is pressed, and allowing all buttons to play the
"Select" sound when clicked.
*/
public class MainMenu : MonoBehaviour
{

    public TitleScreen ts;

    //Progresses to the next scene in Unity, this one allows the player to progress
    //to gameplay
    public void PlayGame ()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quits the game
    public void QuitGame ()
    {
        Application.Quit();
    }

    //Plays the Sekect sound
    public void PlaySound ()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }

}
