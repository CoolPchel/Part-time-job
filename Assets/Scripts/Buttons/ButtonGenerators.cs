using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGenerators : MonoBehaviour, IInteractable
{
    [SerializeField] CartMoving cartScript;
    [SerializeField] Animator butonGAm;
    [SerializeField] List<GameObject> lampR;
    [SerializeField] List<GameObject> lampG;
    [SerializeField] Animator winUi;
    private AudioSource audioSGenerators;
    private bool startinGenerators;
    public int activSwitch;
    public bool meinDoorOpen;

    private void Start()
    {
        audioSGenerators = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if(startinGenerators)
        {
            audioSGenerators.Play();
            butonGAm.SetTrigger("OpenMeinDoor");
            meinDoorOpen = true;
            winUi.SetTrigger("EndLevel");
        }
        
    }

    private void Update()
    {
        if(cartScript.sent && activSwitch == 2)
        {
            startinGenerators = true;
        }
    }

    public void OneLampGeneratWork()
    {
        lampG[0].SetActive(true);
        lampR[0].SetActive(false);
    }

    public void TwoLampGeneratWork()
    {
        lampG[1].SetActive(true);
        lampR[1].SetActive(false);
    }
}
