using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoor : MonoBehaviour
{
    [SerializeField] AudioClip openDoorClip;
    [SerializeField] AudioClip clouseDoorClip;
    private AudioSource audioDoor;
    [SerializeField] Animator doorAnimator;
    private bool onePlay;
    public bool openStartDoor;

    private void Start()
    {
        audioDoor = GetComponent<AudioSource>();
        doorAnimator.SetBool("ClouseDoor", true);
    }

    private void Update()
    {
        if(openStartDoor && !onePlay)
        {
            OpenDoor();
            onePlay = true;
        }
        if(!openStartDoor && onePlay)
        {
            ClouseDoor();
            onePlay = false;
        }
    }

    private void OpenDoor()
    {
        audioDoor.clip = openDoorClip;
        doorAnimator.SetBool("ClouseDoor", false);
        audioDoor.Play();
    }

    private void ClouseDoor()
    {
        audioDoor.clip = clouseDoorClip;
        doorAnimator.SetBool("ClouseDoor", true);
        audioDoor.Play();
    }
}
