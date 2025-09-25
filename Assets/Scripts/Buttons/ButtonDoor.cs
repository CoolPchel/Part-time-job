using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour, IInteractable
{
    [SerializeField] Animator buttonAm;
    [SerializeField] AudioClip openClip;
    [SerializeField] AudioClip clouseClip;
    private AudioSource audioSButtonDoor;
    [SerializeField] AudioClip openDoorClip;
    [SerializeField] AudioClip clouseDoorClip;
    [SerializeField] AudioSource audioDoor;
    public bool clouseDoor;

    private void Awake()
    {
        audioSButtonDoor = GetComponent<AudioSource>();
        if(clouseDoor)
        {
            buttonAm.SetBool("ClouseDoor", true);
        }
        if(!clouseDoor)
        {
            buttonAm.SetBool("ClouseDoor", false);
        }
    }

    public void Interact()
    {
        clouseDoor = !clouseDoor;
        if(clouseDoor)
        {
            buttonAm.SetBool("ClouseDoor", true);
            ClouseSound();
        }
        if(!clouseDoor)
        {
            buttonAm.SetBool("ClouseDoor", false);
            OpenSound();
        }
    }

    public void OpenSound()
    {
        audioSButtonDoor.clip = openClip;
        audioSButtonDoor.PlayDelayed(1);
        audioDoor.clip = openDoorClip;
        audioDoor.PlayDelayed(1.2f);
    }

    public void ClouseSound()
    {
        audioSButtonDoor.clip = clouseClip;
        audioSButtonDoor.PlayDelayed(1);
        audioDoor.clip = clouseDoorClip;
        audioDoor.PlayDelayed(1f);
    }
}
