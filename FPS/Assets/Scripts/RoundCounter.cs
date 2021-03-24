//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Keeps track of what round the player is on
public class RoundCounter : MonoBehaviour
{
    Text text;
    int round = 1;
    int roundKills = 0;
    int roundCap = 5;
    //Gets the text component for the round counter on start
    void Start()
    {
        text = GetComponent<Text>();
    }
    //Increments roundKills everytime a player kills a zombie
    public void addKill()
    {
        roundKills++;
    }
    //Get method for the current round
    public int getRound()
    {
        return round;
    }
    //Transistion method that sets up the next round
    //Amount of kills required to advance increases each round
    public void nextRound()
    {
        round++;
        roundKills = 0;
        roundCap += 5;
    }
    //Progresses the player to the next round if the player kills enough zombies
    //Updates text component
    void Update()
    {
        if (roundKills>=roundCap)
        {
            nextRound();
        }
        text.text = "Round " + round;
    }
}
