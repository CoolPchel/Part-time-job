using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrritatedCam : MonoBehaviour
{
    private CamersInBuilding cameraScript;
    [SerializeField] List<GameObject> irritateds;
    [SerializeField] PublicSettingNPC publicSettingScript; //Скрипт благодаря ему, бот не активен
    public int complexityTime; //Взаимости от сложности игры, будет меньше времени стоять на месте боты
    public float complexityTimeAttack; //взамисоти от сложности игры, будет чаше набеги на игрока
    public int complexityTimeKill; //взамисоти от сложности игры, быстрее наподать
    [SerializeField] int randomNumber;
    private float timeForCheck;
    private float timeForKillPlayer;
    private float timeForAttackPlayer;
    [SerializeField] AudioClip cry;
    [SerializeField] AudioClip screem;
    private AudioSource irritatedCamS;
    private bool onePlay;

    private void Start()
    {
        irritatedCamS = GetComponent<AudioSource>();
        cameraScript = FindObjectOfType<CamersInBuilding>();
        timeForCheck = complexityTime;
        timeForKillPlayer = complexityTimeKill;
        timeForAttackPlayer = complexityTimeAttack;
    }

    private void FixedUpdate()
    {
        if(publicSettingScript.startGameTime)
        {
            if(timeForAttackPlayer > 0)
            {
                timeForCheck -= 1 * Time.deltaTime;
                if(timeForCheck <= 0)
                {
                    RandomPosition();
                }
                timeForAttackPlayer -= 1 * Time.deltaTime;
            }
            if(timeForAttackPlayer <= 0)
            {
                if(cameraScript.soundPlayed)
                {
                    if(cameraScript.numberCameraActive == randomNumber+1)
                    {
                        irritatedCamS.clip = cry;
                        irritatedCamS.loop = false;
                        irritatedCamS.Play();
                        timeForAttackPlayer = complexityTimeAttack;
                        timeForKillPlayer = complexityTimeKill;
                        onePlay = false;
                    }
                    else
                    {
                        cameraScript.soundPlayed = false;
                    }
                }

                if(!cameraScript.soundPlayed)
                {
                    timeForKillPlayer -= 1 * Time.deltaTime;
                    if(!onePlay)
                    {
                        irritatedCamS.clip = screem;
                        PlaySound();
                    }
                }

                if(timeForKillPlayer <= 0)
                {
                    publicSettingScript.IrrtatedKill();
                    publicSettingScript.UiPonelFalse();
                    timeForAttackPlayer = 10;
                }
            }
        }
    }

    private void PlaySound()
    {
        irritatedCamS.clip = screem;
        irritatedCamS.loop = true;
        irritatedCamS.Play();
        onePlay = true;
    }

    private void RandomPosition()
    {
        irritateds[randomNumber].SetActive(false);
        if(cameraScript.numberCameraActive == randomNumber+1)
        {
            publicSettingScript.CamNoise();
        }
        randomNumber = Random.Range(0, irritateds.Count);
        timeForCheck = Random.Range(10, complexityTime);
        irritateds[randomNumber].SetActive(true);
        timeForAttackPlayer += 3;
    }
}
