//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Controls health bar GUI component
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //Set method for max slider and max health values
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //Set method for slider and health values
    public void setHealth(int health)
    {
        slider.value = health;
    }
}
