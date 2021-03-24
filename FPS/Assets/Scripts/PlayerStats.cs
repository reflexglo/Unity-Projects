//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the player's stats
public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;
    public int regenTime = 100;
    public float damageVelocity = -30;
    float currentVelocity = 0;

    bool isFalling = false;

    public PlayerMovement playerMovement;
    public HealthBar healthBar;
    //Sets players health to full on start
    void Start()
    {
        currentHealth = health;
        healthBar.setMaxHealth(health);
    }

    //Keeps track of health regeneration cycle and fall damage
    void Update()
    {
        if (currentHealth < health && regenTime ==0)
        {
            currentHealth += 1;
            healthBar.setHealth(currentHealth);
            regenTime = 100;
        }
        if (regenTime > 0 && currentHealth < health)
        {
            regenTime--;
        }
        if (playerMovement.getVelocity() < damageVelocity)
        {
            isFalling = true;
            currentVelocity = playerMovement.getVelocity();
        }
        if (isFalling == true && playerMovement.getVelocity() > damageVelocity && playerMovement.groundCheck == true)
        {
            isFalling = false;
            takeDamage((int)currentVelocity * -1);
        }
    }
    //Decrements health if player is hit by an enemy
    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }    
}
