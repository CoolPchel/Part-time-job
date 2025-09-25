using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenaratorActivator : MonoBehaviour, IInteractable
{
    [SerializeField] ButtonGenerators buttonGScript;
    [SerializeField] bool firstG;
    [SerializeField] TextMeshPro textNumber;
    private Animator activatorAm;
    private AudioSource audioSGeneratorActivat;
    private bool activGenarator;
    public int numberLaunched;

    private void Start()
    {
        audioSGeneratorActivat = GetComponent<AudioSource>();
        activatorAm = GetComponent<Animator>();
        if(firstG)
        {
            textNumber.text = "A1".ToString();
        }
        if(!firstG)
        {
            textNumber.text = "A2".ToString();
        }
    }

    public void Interact()
    {
        if(activGenarator)
        {
            audioSGeneratorActivat.Play();
            activatorAm.SetTrigger("Start");
            buttonGScript.activSwitch++;
            if(firstG)
            {
                buttonGScript.OneLampGeneratWork();
            }
            if(!firstG)
            {
                buttonGScript.TwoLampGeneratWork();
            }
            activGenarator = false;
        }
    }

    private void Update()
    {
        if(numberLaunched == 4)
        {
            activGenarator = true;
            numberLaunched = 0;
        }
    }
}
