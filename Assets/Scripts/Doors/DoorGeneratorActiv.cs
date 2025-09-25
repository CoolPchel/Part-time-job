using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGeneratorActiv : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource audioSDoorGenerator;
    [SerializeField] AudioClip audioClip;
    private Animator doorGAAm;
    private bool isOpen;

    private void Start()
    {
        doorGAAm = GetComponent<Animator>();
    }

    public void Interact()
    {
        isOpen = !isOpen;
        if(isOpen)
        {
            doorGAAm.SetBool("Open", true);
            audioSDoorGenerator.clip = audioClip;
            audioSDoorGenerator.Play();
        }
        if(!isOpen)
        {
            doorGAAm.SetBool("Open", false);
        }
    }
}
