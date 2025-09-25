using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallFry : MonoBehaviour
{
    private AnimatorNPC npcAm;
    private NavMeshAgent navMeshAgentSmallFry;
    private Transform playerT;
    [SerializeField] float startGameTime;

    void Start()
    {
        navMeshAgentSmallFry = GetComponent<NavMeshAgent>();
        npcAm = GetComponent<AnimatorNPC>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(startGameTime <= 0)
        {
            navMeshAgentSmallFry.SetDestination(playerT.position);
            npcAm.Moving();
        }
        if(startGameTime > 0)
        {
            startGameTime -= 1 * Time.deltaTime;
        }  
    }
}
