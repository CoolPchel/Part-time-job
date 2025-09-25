using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Irritated : MonoBehaviour
{
    private AnimatorNPC amScript;
    private CamersInBuilding cameraScript;
    private NavMeshAgent navMeshAgent;
    [SerializeField] List<Transform> points;
    [SerializeField] float startGameTime; //Время которая бот не активен
    public int complexityTime; //Взаимости от сложности игры, будет меньше времени стоять на месте боты
    public float complexityTimeAttack; //взамисоти от сложности игры, будет чаше набеги на игрока
    public int complexityTimeKill; //взамисоти от сложности игры, быстрее наподать
    private int randomNumber;
    private float timeForCheck; 
    private int lastRandomNumber;
    private float timeForKillPlayer;
    private float timeForAttackPlayer; 

    private void Start()
    {
        amScript = GetComponent<AnimatorNPC>();
        cameraScript = FindObjectOfType<CamersInBuilding>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        timeForCheck = complexityTime;
        timeForKillPlayer = complexityTimeKill;
        timeForAttackPlayer = complexityTimeAttack;
    }

    private void Update()
    {
        if(startGameTime <= 0)
        {
            if(timeForAttackPlayer > 0)
            {
                navMeshAgent.SetDestination(points[randomNumber].position);
                
                if(navMeshAgent.stoppingDistance >= navMeshAgent.remainingDistance)
                {
                    timeForCheck -= 1 * Time.deltaTime;
                    if(timeForCheck <= 0)
                    {
                        RandomPosition();
                    }
                    amScript.StopMoving();
                }
                else
                {
                    amScript.Moving();
                }
                timeForAttackPlayer -= 1 * Time.deltaTime;
            }
            if(timeForAttackPlayer <= 0)
            {
                if(navMeshAgent.stoppingDistance >= navMeshAgent.remainingDistance)
                {
                    if(cameraScript.soundPlayed)
                    {
                        if(cameraScript.numberCameraActive == randomNumber)
                        {
                            timeForAttackPlayer = complexityTimeAttack;
                            timeForKillPlayer = complexityTimeKill;
                        }
                        else
                        {
                            cameraScript.soundPlayed = false;
                        }
                    }
                    if(!cameraScript.soundPlayed)
                    {
                        timeForKillPlayer -= 1 * Time.deltaTime;
                        print("Шум");
                    }
                    if(timeForKillPlayer == 0)
                    {
                        print("Игрок проиграл");
                    }
                    amScript.StopMoving();
                }
                else
                {
                    amScript.Moving();
                }
            }
        }
        if(startGameTime > 0)
        {
            startGameTime -= 1 * Time.deltaTime;
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
        timeForCheck = Random.Range(6, complexityTime);
        timeForAttackPlayer += 3;
    }
}
