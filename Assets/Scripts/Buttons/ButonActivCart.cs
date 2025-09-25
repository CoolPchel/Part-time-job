using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonActivCart : MonoBehaviour, IInteractable
{
    [SerializeField] CartMoving cartScript;
    [SerializeField] Animator buttonActivAm;
    [SerializeField] StartDoor startDoorS;
    private AudioSource audioSCart;
    public bool nextChapter;

    private void Start()
    {
        audioSCart = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(cartScript.filled && cartScript.waitingAction)
        {
            buttonActivAm.SetBool("Activ", false);
        }
    }

    public void Interact()
    {
        if(cartScript.waitingAction)
        {
            audioSCart.Play();
            if(!startDoorS.openStartDoor)
            {
                startDoorS.openStartDoor = true;
            }
            else
            {
                startDoorS.openStartDoor = false;
                nextChapter = true;
            }
            cartScript.waitingAction = false;
            buttonActivAm.SetBool("Activ", true);
        }
    }
}
