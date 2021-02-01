//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls movement and behavior of newly spawned meteors
public class MeteorMovement : MonoBehaviour
{
    public Transform planet;
    public int gravity = -20;
    bool destroyed = false;
    bool isSeed = false;
    public GameObject explosion;
    //Determines whether meteor is the seed meteor or not at start
    void Start()
    {
        if (transform.position.x == 0 && transform.position.y == 0 && transform.position.z == 0)
        {
            isSeed = true;
        }
    }

    // Updates rotation of meteor
    void Update()
    {
        if (!destroyed&&!isSeed) {
            Vector3 gravityDir = (transform.position - planet.position).normalized;
            Vector3 meteorUp = transform.up;
            Quaternion gravRotation = Quaternion.FromToRotation(meteorUp, gravityDir) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, gravRotation, 50 * Time.deltaTime);
            transform.GetComponent<Rigidbody>().AddForce(gravityDir * gravity);
        }
    }
    //Detects collision between meteor and any object attached to the planet
    //Then destroys said meteor creating an explosion
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            if (!isSeed) {
                GameObject newExplosion = Instantiate(explosion, transform.position,transform.rotation);
                Destroy(newExplosion, 1.5f);
                Destroy(transform.gameObject);
                destroyed = true;
            }
        }
    }
}
