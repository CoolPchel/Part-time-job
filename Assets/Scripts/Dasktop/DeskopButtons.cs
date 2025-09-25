using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskopButtons : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject door;
    [SerializeField] Animator animButton;
    [SerializeField] AudioSource audioSDeskop;
    private CartMoving trolleyMScript;
    public bool workButton;
    private bool clouseDoor;

    private void Start()
    {
        if(!workButton)
        {
            Destroy(gameObject);
        }
        trolleyMScript = FindObjectOfType<CartMoving>();
    }

    private void Update()
    {
        if(clouseDoor)
        {
            trolleyMScript.stopFilled = true;
        }
        if(!clouseDoor)
        {
            trolleyMScript.stopFilled = false;
        }
    }

    public void Interact()
    {
        if(workButton)
        {
            audioSDeskop.Play();
            clouseDoor = !clouseDoor;
            if(!clouseDoor)
            {
                animButton.SetBool("ClouseDoor", false);
                door.SetActive(false);
            }
            if(clouseDoor)
            {
                animButton.SetBool("ClouseDoor", true);
                door.SetActive(true);
            }
        }
    }
}
