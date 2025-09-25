using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] ButtonGenerators buttonGScript;

    public void Interact()
    {
        if(buttonGScript.meinDoorOpen)
        {
            print("Сбежал");
        }
        
    }
}
