using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskopFuncthion : MonoBehaviour, IInteractable
{
    private FirstPersonLook fplCB;
    private FirstPersonMovement fpmCB;
    [SerializeField] GameObject uiInterface;
    public bool monitorOn;
    public bool canExit;

    private void Awake()
    {
        fplCB = FindObjectOfType<FirstPersonLook>();
        fpmCB = FindObjectOfType<FirstPersonMovement>();
    }
    
    public void Interact()
    {
        TabletAmFunction();
    }

    private void Update()
    {
        if(monitorOn && Input.GetKeyDown(KeyCode.E) && canExit)
        {
            canExit = false;
            monitorOn = false;
            TabletAmFunction();
        }
    }

    private void TabletAmFunction()
    {
        Animator deskopAnimator = gameObject.GetComponent<Animator>();
        if(monitorOn)
        {
            deskopAnimator.SetBool("MonitorOn", true);
            uiInterface.SetActive(false);
            fplCB.sensitivity = 0;
            fpmCB.speed = 0;
            fpmCB.canRun = false;
        }
        if(!monitorOn)
        {
            deskopAnimator.SetBool("MonitorOn", false);
            uiInterface.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            fplCB.sensitivity = 2;
            fpmCB.speed = 2;
            fpmCB.canRun = true;
        }
    }
}
