using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PublicSettingNPC : MonoBehaviour
{
    public bool startGameTime;
    [SerializeField] Animator camScream;
    [SerializeField] Animator noiseAm;
    [SerializeField] List<GameObject> uiPonels;//InterFace && CameraPonel
    [SerializeField] TextMeshProUGUI uiText;
    private AudioSource audioSNPC;

    private void Start()
    {
        audioSNPC = GetComponent<AudioSource>();
    }

    public void DestroyRobotSW()
    {
        camScream.SetTrigger("DestroyW");
    }

    public void WanderingSKill()
    {
        audioSNPC.Play();
        camScream.SetTrigger("WanderingSKill");
        uiText.text = "Новые-Блуждающие, блуждают по коридорам здания, они вас не видят, но могут почуствовать, не прикосайтесь к ним!";
        startGameTime = false;
    }

    public void WanderingKill()
    {
        audioSNPC.Play();
        camScream.SetTrigger("WanderingKill");
        uiText.text = "Блуждающий любит блуждать по зданию, и иногда может заглянуть и к вам, закрывайте двери, чтобы защититься от этого.";
        startGameTime = false;
    }

    public void IrrtatedKill()
    {
        audioSNPC.Play();
        camScream.SetTrigger("IrrtatedKill");
        uiText.text = "Раздраженного, очень сильно раздрожает звук техники, из за это оно беситься, чтобы избежать визита, возпроизводите успокаюшие звуки.";
        startGameTime = false;
    }
    
    public void SmallFryKill()
    {
        audioSNPC.Play();
        camScream.SetTrigger("SmallFryKill");
        uiText.text ="Раздраженного, очень сильно раздрожает звук техники, из за это оно беситься, чтобы избежать визита, возпроизводите успокаюшие звуки.";
        startGameTime = false;
    }

    public void UiPonelFalse()
    {
        uiPonels[0].SetActive(false);
        uiPonels[1].SetActive(false);
    }

    public void CamNoise()
    {
        noiseAm.SetTrigger("SwithCam");
    }
}
