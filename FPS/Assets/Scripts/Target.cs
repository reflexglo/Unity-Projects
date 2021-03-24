//Chris Riordan
//6-14-2020
using System;
using UnityEngine;
//Controller class for enemy stats
public class Target : MonoBehaviour
{
    public PlayerStats player;
    public PlayerMovement playerMove;
    public Transform spawnLocation;
    public GameObject parent;
    public MoneyCounter money;
    public RoundCounter round;
    public float health = 50f;
    public float maxHealth = 50f;
    public int damage = 2;
    bool takingDamage = false;
    int damageTimer = 0;
    //Controls the enemy's attack cycle and applies damage to player if player is hit
    public void Update()
    {
        maxHealth = round.getRound() * 50f;
        damage = round.getRound() * 2;
        if (damageTimer > 0)
        {
            damageTimer--;
        }
        if (takingDamage && damageTimer == 0)
        {
            player.takeDamage(damage);
            damageTimer = 30;
        }
        playerMove.slowMove(takingDamage);
    }
    //Decrements health if player shoots enemy
    //If health goes below 0, the enemy dies
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    //Destroys current enemy and spawns a completely new one to replace it
    void Die()
    {
        health = maxHealth;
        gameObject.transform.localPosition = spawnLocation.position;
        money.addMoney(500);
        round.addKill();
    }
    //Detects if player is within the enemy's attack radius
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            takingDamage = true;
        }
    }
    //Detects if player has left the enemy's attack radius
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            takingDamage = false;
        }
    }
}

