//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Controls objective text
public class ObjectiveController : MonoBehaviour
{
    public Text obj;
    public PlayerMovement player;
    public MouseLook mouse;
    //Sets text to initial objective
    void Start()
    {
        obj.text = "Objective: Find ship key.";
        obj.gameObject.SetActive(true);
    }

    // Updates objective text based on player progression
    void Update()
    {
        if (!mouse.getEnd()) {
            if (player.getKey())
            {
                if (player.getRange())
                {
                    obj.text = "Objective: Enter ship.";
                }
                else
                {
                    obj.text = "Objective: Return to ship.";
                }
            }
            else
            {
                obj.text = "Objective: Find ship key.";
            }
        }
        else
        {
            obj.gameObject.SetActive(false);
        }
    }
}
