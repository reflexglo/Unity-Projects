//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Controls health bar UI
public class HealthControl : MonoBehaviour
{
    public Slider slider;
    //sets max value of slider and current value of slider to the max value
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //set method for slider value of health
    public void setHealth(float health)
    {
        slider.value = health;
    }
}
