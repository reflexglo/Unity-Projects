//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Responsible for controlling the spawn of meteors
public class MeteorControl : MonoBehaviour
{
    public GameObject meteorSeed;
    public PlayerMovement player;
    public int cooldown = 200;
    int timer;
    public int spawnRadius = 50;
    //Sets timer to the meteor spawn cooldown and adds the radius of the planet (25) to the spawn radius
    void Start()
    {
        timer = cooldown;
        spawnRadius += 25;
    }
    //Updates timer and spawns meteor at timer = 0
    void Update()
    {
        if (player.halfTime())
        {
            if (timer>0)
            {
                timer--;
            }
            else
            {
                timer = cooldown;
                Instantiate(meteorSeed,getSpawn(spawnRadius),new Quaternion(0,0,0,0));
            }
        }
    }
    //Get method for spawn position for next meteor
    //Picks random point of surface of sphere with radius = spawnRadius as spawn position
    public Vector3 getSpawn(int radius)
    {
        float z = Random.Range(-radius, radius);
        float angleDeg = Random.Range(0,360);
        float angleRad = (angleDeg * Mathf.PI) / 180;
        float newRadius = Mathf.Sqrt((radius*radius)-(z*z));
        float x = newRadius * Mathf.Cos(angleRad);
        float y = newRadius * Mathf.Sin(angleRad);
        return new Vector3(x, y, z);
    }
}
