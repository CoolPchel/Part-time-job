using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PempeSounds : MonoBehaviour
{
    private AudioSource pumpeAudio;
    [SerializeField] AudioClip startWork;
    [SerializeField] AudioClip pumpeWork;
    [SerializeField] AudioClip endWork;
    private ButtonFillingLiquid fillingLiquid;
    private bool onePlaySound;
    private bool twoPlaySound;
    private float time = 7;

    private void Start()
    {
        fillingLiquid = FindObjectOfType<ButtonFillingLiquid>();
        pumpeAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(fillingLiquid.pumpeIsWork && !twoPlaySound)
        {
            StartWork();
            twoPlaySound = true;
        }
        if(!fillingLiquid.pumpeIsWork && !onePlaySound && fillingLiquid.onePlay)
        {
            EndWork();
            onePlaySound = true;
        }

        if(onePlaySound && time > 0)
        {
            if(time != 0)
            {
                time -= 1 * Time.deltaTime;
            }
            if(time <= 0)
            {
                PumpeWork();
                onePlaySound = false;
            }
        }
    }

    private void StartWork()
    {
        pumpeAudio.clip = startWork;
        pumpeAudio.Play();
        onePlaySound = true;
    }
    private void PumpeWork()
    {
        pumpeAudio.clip = pumpeWork;
        pumpeAudio.loop = true;
        pumpeAudio.Play();
    }
    private void EndWork()
    {
        pumpeAudio.clip = endWork;
        pumpeAudio.loop = false;
        pumpeAudio.Play();
    }
}
