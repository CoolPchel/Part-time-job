using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorNPC : MonoBehaviour
{
    private Animator animatorm;
    private int number;
    private float kolDown;
    private bool randomAm = true;

    private void Start()
    {
        animatorm = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!randomAm && kolDown > 0)
        {
            kolDown -= 1 * Time.deltaTime;
        }
        if(!randomAm && kolDown <= 0)
        {
            randomAm = true;
        }
    }

    public void endIdl()
    {
        animatorm.SetBool("Idl" + number, false);
    }

    public void RandomIdl()
    {
        if(randomAm)
        {
            number = Random.Range(1, 2+1);
            animatorm.SetBool("Idl" + number, true);
            kolDown = 40;
            randomAm = false;
        }
    }

    public void Moving()
    {
        animatorm.SetBool("Move", true);
    }

    public void StopMoving()
    {
        animatorm.SetBool("Move", false);
    }
}
