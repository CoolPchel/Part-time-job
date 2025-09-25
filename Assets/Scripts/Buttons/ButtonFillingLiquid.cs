using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonFillingLiquid : MonoBehaviour, IInteractable
{
    [SerializeField] CartMoving cartScript;
    [SerializeField] TextMeshPro textFilling;
    [SerializeField] Animator fillingAm;
    [SerializeField] List<GameObject> bulbWorks;
    [SerializeField] List<GameObject> bulbWorksR;
    [SerializeField] List<GameObject> bulbWorksY;
    [SerializeField] List<GameObject> bulbWorksG;
    [SerializeField] GameObject fillingArow;
    [SerializeField] GameObject stopFillingWorning;
    [SerializeField] GameObject offMonitor;
    [SerializeField] StartDoor startDoorS;
    private AudioSource audioSFilling;
    private PublicSettingNPC publicSettingScript;
    private int number;
    public bool onePlay;
    public bool pumpeIsWork;

    private void Start()
    {
        audioSFilling = GetComponent<AudioSource>();
        publicSettingScript = FindObjectOfType<PublicSettingNPC>();
    }

    private void Update()
    {
        if(cartScript.onSite && !onePlay && cartScript.fullness == 0 && !publicSettingScript.startGameTime)
        {
            bulbWorks[number].SetActive(false);
            bulbWorksR[number].SetActive(true);
        }
        if(cartScript.fullness < 100 && onePlay)
        {
            bulbWorksR[number].SetActive(false);
            bulbWorksY[number].SetActive(true);
            onePlay = false;
        }
        if(cartScript.fillingLiquid)
        {
            textFilling.text = cartScript.fullness.ToString("0") + "%"; 
            if(cartScript.fullness >= 99.8f && !onePlay)
            {
                publicSettingScript.startGameTime = false;
                bulbWorksY[number].SetActive(false);
                bulbWorksG[number].SetActive(true);
                fillingAm.SetBool("Push", false);
                startDoorS.openStartDoor = true;
                onePlay = true;
                pumpeIsWork = false;
            }

            if(cartScript.fillingContinium)
            {
                fillingArow.SetActive(true);
                stopFillingWorning.SetActive(false);
            }
            if(!cartScript.fillingContinium)
            {
                fillingArow.SetActive(false);
                stopFillingWorning.SetActive(true);
            }
        }
    }

    public void Interact()
    {
        if(cartScript.onSite && cartScript.fullness == 0)
        {
            audioSFilling.Play();
            pumpeIsWork = true;
            startDoorS.openStartDoor = false;
            publicSettingScript.startGameTime = true;
            fillingAm.SetBool("Push", true);
            cartScript.fillingLiquid = true;
            onePlay = true;
            offMonitor.SetActive(false);
        }
    }
}
