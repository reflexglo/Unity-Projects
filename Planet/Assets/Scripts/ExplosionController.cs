//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls explosion object
public class ExplosionController : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject playerModel;
    public float blastRadius = 10;
    public float damageMultiplier = 2;
    //detects collision between explosion and player then applies corresponding damage
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlayerModel")
        {
            float distance = Vector3.Distance(transform.position,playerModel.transform.position);
            player.setHealth(damageMultiplier*(blastRadius-distance));
        }
    }
}
