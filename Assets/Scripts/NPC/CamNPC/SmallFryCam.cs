using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallFryCam : MonoBehaviour
{
    private NavMeshAgent navMeshAgentSmallFryCam;
    [SerializeField] List<Transform> points;
    [SerializeField] List<Transform> playerSite;
    [SerializeField] PublicSettingNPC publicSettingScript; //Скрипт благодаря ему, бот не активен
    private int randomNumber;
    private float timeForCheck;
    private int lastRandomNumber;
    public int complexityTime;
    public bool nearPlayer;
    private NearPlayer nearPlayerScript;
    private bool attackPlayer;

    private void Start()
    {
        navMeshAgentSmallFryCam = GetComponent<NavMeshAgent>();
        timeForCheck = complexityTime;
    }

    private void Update()
    {
        if(publicSettingScript.startGameTime)
        {
            if(!nearPlayer)
            {
                navMeshAgentSmallFryCam.SetDestination(points[randomNumber].position);

                if(navMeshAgentSmallFryCam.stoppingDistance >= navMeshAgentSmallFryCam.remainingDistance)
                {
                    timeForCheck -= 1 * Time.deltaTime;
                    if(timeForCheck <= 0)
                    {
                        RandomPosition();
                    }  
                }
            }
            if(nearPlayer && attackPlayer)
            {
                timeForCheck -= 1 * Time.deltaTime;
                if(timeForCheck <= 0)
                {
                    if(nearPlayerScript.doorOpen)
                    {
                        navMeshAgentSmallFryCam.SetDestination(playerSite[nearPlayerScript.number].position);
                    }
                    if(!nearPlayerScript.doorOpen)
                    {
                        randomNumber = 0;
                        nearPlayer = false;
                        attackPlayer = false;
                        nearPlayerScript = null;
                    }
                }
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NearPlayer")
        {
            nearPlayer = true;
            if(other.gameObject.GetComponent<NearPlayer>() != null)
            {
                nearPlayerScript = other.gameObject.GetComponent<NearPlayer>();
            }
        }
        if(other.tag != "NearPlayer")
        {
            nearPlayer = false;
        }
        if(other.tag == "Finish")
        {
            publicSettingScript.SmallFryKill();
            publicSettingScript.UiPonelFalse();
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
        timeForCheck = Random.Range(complexityTime-2, complexityTime);

        if(points[randomNumber].tag == "NearPlayer")
        {
            attackPlayer = true;
            timeForCheck += 5;
        }
    }
}
