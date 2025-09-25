using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CartMoving : MonoBehaviour
{
    private NavMeshAgent navMeshAgentCart;
    [SerializeField] List<Transform> points;
    [SerializeField] Transform pointStart;
    [SerializeField] Transform pointHome;
    [SerializeField] List<ButtonDoor> meinDoor;
    [SerializeField] AnimatorTrolley trolleyAm;
    private int passedPoint = -1;
    public bool stopFilled; //кнопки вентеляции управляют bool
    public bool onSite;
    public bool waitingAction = true;
    public bool fillingLiquid; 
    public float fullness;
    public bool filled;
    public bool sent;
    public bool fillingContinium; //Bool использует Button filling Liquid

    private void Start()
    {
        navMeshAgentCart = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(!onSite && !waitingAction)
        {
            if(navMeshAgentCart.stoppingDistance >= navMeshAgentCart.remainingDistance)
            {
                trolleyAm.Move();
                passedPoint++;
                navMeshAgentCart.SetDestination(points[passedPoint].position);
            }
        }

        if(fillingLiquid && !meinDoor[0].clouseDoor && !meinDoor[1].clouseDoor && !stopFilled)
        {
            fullness += 0.5f * Time.deltaTime;
            if(fullness >= 100)
            {
                waitingAction = true;
                filled = true;
                fillingLiquid = false;
            }
            fillingContinium = true;
        }

        if(meinDoor[0].clouseDoor || meinDoor[1].clouseDoor || stopFilled)
        {
            fillingContinium = false;
        }

        if(filled && !waitingAction && !sent)
        {
            if(navMeshAgentCart.stoppingDistance >= navMeshAgentCart.remainingDistance && passedPoint != 0)
            {
                trolleyAm.Move();
                passedPoint--;
                navMeshAgentCart.SetDestination(points[passedPoint].position);
            }
            if(passedPoint == 0)
            {
                navMeshAgentCart.SetDestination(pointHome.position);
                sent = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AimCart")
        {
            trolleyAm.Stop();
            onSite = true;
        }
    }
}
