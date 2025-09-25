using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivRobots : MonoBehaviour, IInteractable
{
    [SerializeField] AnimatorPlayer mainCamAm;
    [SerializeField] List<GameObject> robot;
    [SerializeField] List<Animator> doorsAm;
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform playerT;
    [SerializeField] List<Transform> robotPosition;
    [SerializeField] EyeRobots eyeRobotScript;
    [SerializeField] GameObject flahsLightPlayer;
    [SerializeField] GameObject robotPlayer;
    [SerializeField] GameObject flashLightPlayer;
    [SerializeField] GameObject wallBlock;
    [SerializeField] AudioClip onMoniotor;
    [SerializeField] AudioClip destroyRobotS;
    private AudioSource audioSRobots;
    public bool isRobot;
    public int destroidRobots;

    private void Start()
    {
        audioSRobots = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if(!isRobot && destroidRobots != 2)
        {
            PlayMonitorSound();
            eyeRobotScript.ToggleNightVision();
            robotPlayer.SetActive(true);
            flahsLightPlayer.SetActive(true);
            playerT.position = robotPosition[destroidRobots].position;
            robot[destroidRobots].SetActive(false);
            doorsAm[0].SetBool("ClouseDoor", true);
            doorsAm[1].SetBool("ClouseDoor", true);
            mainCamAm.menPlayer = false;
            isRobot = true;
        }
    }

    private void Update()
    {
        if(isRobot)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                mainCamAm.menPlayer = true;
            }
        }
        if(destroidRobots >= 2)
        {
            flashLightPlayer.SetActive(true);
            if(wallBlock != null)
            {
                Destroy(wallBlock);
            }
        }
    }

    public void ExitRobot()
    {
        PlayMonitorSound();
        eyeRobotScript.ToggleNightVision();
        robotPlayer.SetActive(false);
        flahsLightPlayer.SetActive(false);
        robotPosition[destroidRobots].position = playerT.position;
        robot[destroidRobots].SetActive(true);
        playerT.position = playerPosition.position;
        isRobot = false;
    }

    private void PlayMonitorSound()
    {
        audioSRobots.clip = onMoniotor;
        audioSRobots.Play();
    }

    public void PlayDestroySound()
    {
        audioSRobots.clip = destroyRobotS;
        audioSRobots.Play();
    }

    public void DestroyRobot()
    {
        if(destroidRobots != 2)
        {
            ExitRobot();
            destroidRobots++;
        }
    }
}
