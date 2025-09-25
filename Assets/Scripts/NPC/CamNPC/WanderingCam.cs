using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingCam : MonoBehaviour
{
    [SerializeField] PublicSettingNPC publicSettingScript; //Скрипт благодаря ему, бот не активен
    public int complexityTime; //Взаимости от сложности игры, будет меньше времени стоять на месте боты
    private float timeForCheck;
    private float timeWeatPlayer;
    public int assignedTime; // Взаимости от сложности игры, бот будет стоять возле двери игрока
    public float percentAttack; //взамисоти от сложности игры, будет чаше набеги на игрока
    public int randomSuccessfulAttack = 100; //проценты на атаку
    private bool attackPlayer;
    private int randomNumber;
    private CamersInBuilding cameraScript;
    [SerializeField] List<ButtonDoor> meinDoor;
    [SerializeField] List<GameObject> wanderingAttak;
    [SerializeField] List<GameObject> wanderings;
    [SerializeField] List<AudioSource> wanderingAttakS;
    private bool onePlay;

    private void Start()
    {
        cameraScript = FindObjectOfType<CamersInBuilding>();
        timeForCheck = complexityTime;
        timeWeatPlayer = assignedTime;
    }

    private void FixedUpdate()
    {
        if(publicSettingScript.startGameTime)
        {
            if(!attackPlayer)
            {
                timeForCheck -= 1 * Time.deltaTime;
                if(timeForCheck <= 0)
                {
                    RandomPosition();
                    WillAttack();
                }
            }
            if(attackPlayer)
            {
                if(!onePlay)
                {
                    PlaySound();
                }

                timeWeatPlayer -= 1 * Time.deltaTime;
                if(timeWeatPlayer <= 0)
                {
                    if(!meinDoor[randomNumber].clouseDoor)
                    {
                        publicSettingScript.WanderingKill();
                        publicSettingScript.UiPonelFalse();
                    }

                    if(meinDoor[randomNumber].clouseDoor)
                    {
                        wanderingAttak[randomNumber].SetActive(false);
                        onePlay = false;
                        RandomPosition();
                    }
                    attackPlayer = false;
                }
            }
        }
    }

    private void RandomPosition()
    {
        if(cameraScript.numberCameraActive == randomNumber)
        {
            publicSettingScript.CamNoise();
        }
        wanderings[randomNumber].SetActive(false);
        timeForCheck = Random.Range(10, complexityTime);
        randomNumber = Random.Range(0, wanderings.Count);
        wanderings[randomNumber].SetActive(true);
    }

    private void WillAttack()
    {
        randomSuccessfulAttack = Random.Range(0, 101);
        timeWeatPlayer = assignedTime;

        if(wanderings[randomNumber].tag == "NearPlayer")
        {
            percentAttack = percentAttack * 1.5f;
        }
        else
        {
            percentAttack = 20;
        }

        if(percentAttack > randomSuccessfulAttack)
        {
            attackPlayer = true;
            wanderings[randomNumber].SetActive(false);
            randomNumber = Random.Range(0, wanderingAttak.Count);
            wanderingAttak[randomNumber].SetActive(true);
        }
    }

    private void PlaySound()
    {
        wanderingAttakS[randomNumber].Play();
        onePlay = true;
    }
}
