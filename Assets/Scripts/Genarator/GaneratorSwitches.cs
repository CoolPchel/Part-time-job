using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaneratorSwitches : MonoBehaviour, IInteractable
{
    [SerializeField] bool isWork;
    [SerializeField] GenaratorActivator generatorAScript;
    [SerializeField] AudioSource audioSGenaratorSwit;
    [SerializeField] AudioClip audioClip;
    private Animator switchesAm;
    private bool dont;

    private void Start()
    {
        switchesAm = GetComponent<Animator>();
        if(isWork && !dont)
        {
            switchesAm.SetTrigger("Swithches");
            generatorAScript.numberLaunched++;
            isWork = false;
            dont = true;
        }
    }

    public void Interact()
    {
        if(!isWork && !dont)
        {
            audioSGenaratorSwit.clip = audioClip;
            audioSGenaratorSwit.Play();
            switchesAm.SetTrigger("Swithches");
            generatorAScript.numberLaunched++;
            isWork = true;
            dont = true;
        }
    }
}
