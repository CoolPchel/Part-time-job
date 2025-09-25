using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikBackFon : MonoBehaviour
{
    [SerializeField] AudioClip noCameraClip;
    [SerializeField] AudioClip cameraClip;
    private AudioSource audioSBackFon;
    private CamersInBuilding cameraBulding;
    private bool onePlay;

    private void Start()
    {
        audioSBackFon = GetComponent<AudioSource>();
        cameraBulding = FindObjectOfType<CamersInBuilding>();
    }

    private void Update()
    {
        if(cameraBulding.camerIn && onePlay)
        {
            CameraBackFon();
            onePlay = false;
        }

        if(!cameraBulding.camerIn && !onePlay)
        {
            NoCameraBackFon();
            onePlay = true;
        }
    }

    private void CameraBackFon()
    {
        audioSBackFon.clip = cameraClip;
        audioSBackFon.Play();
    }

    private void NoCameraBackFon()
    {
        audioSBackFon.clip = noCameraClip;
        audioSBackFon.Play();
    }
}
