using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    [SerializeField] AudioSource audioStepPlayer;
    [SerializeField] AudioClip clipStep;
    [SerializeField] AudioClip clipStepRobot;
    private ActivRobots activRobotsScript;
    private bool onePlay;

   private void Start()
   {
        activRobotsScript = FindObjectOfType<ActivRobots>();
   }

   private void Update()
   {
        if(activRobotsScript.isRobot && !onePlay)
        {
            audioStepPlayer.Stop();
            audioStepPlayer.clip = clipStepRobot;
            onePlay = true;
        }
        if(!activRobotsScript.isRobot && onePlay)
        {
            audioStepPlayer.Stop();
            audioStepPlayer.clip = clipStep;
            onePlay = false;
        }
   }
}
