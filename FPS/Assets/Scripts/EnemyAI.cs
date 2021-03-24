//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Controls enemy movement
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent nm;
    public Transform target;
    public RoundCounter round;
    public float speed = 2.6f;

    //Initializes navigation mesh on start
    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
    }

    //calculates speed of enemy and sets the player as the target destination
    void Update()
    {
        nm.speed = speed * round.getRound();
        nm.SetDestination(target.position);
    }
}
