//Chris Riordan
//6-14-2020
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the upgrade machine
public class PackCol : MonoBehaviour
{
    bool isPacking;
    //Get method for the player's upgrade status
    public bool getPack()
    {
        return isPacking;
    }
    //Detects if the player is within the upgrade machine's upgrade radius
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            isPacking = true;
        }
    }
    //Detects if the player has left the upgrade machine's upgrade radius
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            isPacking = false;
        }
    }
}
