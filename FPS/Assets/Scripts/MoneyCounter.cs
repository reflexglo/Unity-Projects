//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Keeps track of the money obtained by the player
public class MoneyCounter : MonoBehaviour
{
    Text text;
    public int money = 0;
    //Gets the text component for the money counter on start
    void Start()
    {
        text = GetComponent<Text>();
    }
    //Increments money everytime the player kills a zombie
    public void addMoney(int dollar)
    {
        money += dollar;
    }
    //Updates text component
    void Update()
    {
        text.text = "$"+money.ToString();
    }
}
