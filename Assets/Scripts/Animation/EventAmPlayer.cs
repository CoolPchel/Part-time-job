using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventAmPlayer : MonoBehaviour
{
    private FirstPersonLook fpl;
    private FirstPersonMovement fpm;
    private ActivRobots robotScript;
    [SerializeField] Animator animatorDieUI;

    private void Start()
    {
        robotScript = FindObjectOfType<ActivRobots>();
        fpl = FindObjectOfType<FirstPersonLook>();
        fpm = FindObjectOfType<FirstPersonMovement>();
    }

    public void DestroyRobot()
    {
        robotScript.DestroyRobot();
    }

    public void PlayDestroySound()
    {
        robotScript.PlayDestroySound();
    }

    public void StartAmDie()
    {
        animatorDieUI.SetTrigger("StartAm");
    }

    public void BlockMove()
    {
        fpl.canLook = false;
        fpm.canMove = false;
    }

    public void UnBlockMove()
    {
        fpl.canLook = true;
        fpm.canMove = true;
    }

    public void ExitRobot()
    {
        robotScript.ExitRobot();
        fpm.canMove = true;
        fpl.canLook = true;
    }
}
