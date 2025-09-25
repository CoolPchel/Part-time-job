using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButtonDoor : MonoBehaviour
{
    [SerializeField] Animator meinDoorAm;
    public void DoorOpen()
    {
        meinDoorAm.SetBool("ClouseDoor", false);
    }
    public void ClouseOpen()
    {
        meinDoorAm.SetBool("ClouseDoor", true);
    }
}
