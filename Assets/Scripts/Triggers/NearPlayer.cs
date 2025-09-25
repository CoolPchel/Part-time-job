using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPlayer : MonoBehaviour
{
    public int number;
    [SerializeField] GameObject door;
    public bool doorOpen;

    private void FixedUpdate()
    {
        if(door.activeInHierarchy == true)
        {
            doorOpen = false;
        }
        if(door.activeInHierarchy == false)
        {
            doorOpen = true;
        }
    }
}
