using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
This class returns the player back to the main menu when the game is over.
*/
public class Player2_Return : MonoBehaviour
{

    //This method returns the player to the main menu
    public void MainMenu2 ()
    {
        AudioManager.instance.Stop("End Music");
        FindObjectOfType<AudioManager>().Play("Select");
        FindObjectOfType<AudioManager>().Play("Menu Music");
        SceneManager.LoadScene(1);
    }
}
