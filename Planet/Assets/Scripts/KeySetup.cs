//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Sets up key spawn location and controls key interactions
public class KeySetup : MonoBehaviour
{
    public GameObject spawnList;
    public GameObject text;
    bool inRange;
    bool hasKey;
    public PlayerMovement player;
    //Sets fields to their initial values and chooses random spawn out of the spawn list
    void Start()
    {
        int numSpawns = spawnList.transform.childCount;
        int spawn = Random.Range(0, numSpawns);
        transform.position = spawnList.transform.GetChild(spawn).transform.GetChild(0).position;
        text.gameObject.SetActive(false);
        inRange = false;
        hasKey = false;
    }

    //Updates the pickup text element of the key
    void Update()
    {
        if (!hasKey) { 
        if (inRange)
        {
            text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                text.gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                hasKey = true;
                player.setKey(true);
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
    }
    //Detects if player is within range of the key
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "PlayerModel")
        {
            inRange = true;
        }
    }
    //Detects if player becomes out of range with the key
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "PlayerModel")
        {
            inRange = false;
        }
    }
}
