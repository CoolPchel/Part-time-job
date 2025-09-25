using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    private AnimatorNPC amScript;
    private NavMeshAgent navMeshAgent;
    [SerializeField] List<Transform> points;
    [SerializeField] ActivRobots robotScript;
    [SerializeField] PublicSettingNPC psnpc;
    private bool attackPlayer;
    private int randomNumber;
    private int lastRandomNumber;
    public bool startGameTime; //Время которая бот не активен
    private float timeForCheck;


    private void Start()
    {
        amScript = GetComponent<AnimatorNPC>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(startGameTime)
        {
            if(!attackPlayer)
            {
                navMeshAgent.SetDestination(points[randomNumber].position);
                amScript.Moving();
            }

            if(navMeshAgent.stoppingDistance >= navMeshAgent.remainingDistance)
            {
                timeForCheck -= 1 * Time.deltaTime;
                if(timeForCheck <= 0)
                {
                    RandomPosition();
                }
                amScript.StopMoving();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(robotScript.destroidRobots != 2)
            {
                psnpc.DestroyRobotSW();
            }
            if(robotScript.destroidRobots == 2)
            {
                psnpc.WanderingSKill();
            }
        }
    }

    private void RandomPosition()
    {
        randomNumber = Random.Range(0, points.Count);
        while(randomNumber == lastRandomNumber)
        {
            randomNumber = Random.Range(0, points.Count);
        }
        lastRandomNumber = randomNumber;
        timeForCheck = Random.Range(2, 5);
    }
}
