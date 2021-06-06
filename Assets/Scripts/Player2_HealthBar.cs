//Code taken from: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=825s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
This class connects the player's health bar to the health variable
*/

public class Player2_HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //When game starts, set the health bar to the full health value
    public void SetMaxHealth2(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    //Update the health bar
    public void SetHealth2(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
