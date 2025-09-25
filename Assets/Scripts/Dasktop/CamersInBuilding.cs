using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CamersInBuilding : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private DeskopFuncthion deskopF;
    [SerializeField] LastCameraActive lastCameraAScript;
    [SerializeField] List<InfoCamUI> listCamers;
    [SerializeField] List<AudioSource> listAudio;
    [SerializeField] GameObject uiPonel;
    [SerializeField] Transform point; //Игрок должен переместиться на эту точку
    [SerializeField] Transform playerPosition;
    [SerializeField] AudioClip enterCam;
    [SerializeField] AudioClip nextCam;
    [SerializeField] AudioClip exitCam;
    private AudioSource audioSCameraBilding;
    public bool camerIn;
    public int numberCameraActive;
    public bool soundPlayed;

    private void Start()
    {
        audioSCameraBilding = GetComponent<AudioSource>();
        deskopF = GetComponent<DeskopFuncthion>();
    }

    public void ActiveCamera()
    {
        for(int i = 0; i < listCamers.Count; i++)
        {
            listCamers[i].camInfo.depth = -1;
        }
        audioSCameraBilding.clip = nextCam;
        audioSCameraBilding.Play();
        listCamers[numberCameraActive].camInfo.depth = 1;
        lastCameraAScript.numberLastActiveCam = numberCameraActive;
        lastCameraAScript.NextCam();
    }

    public void EnterCamera() //используют анимации в ивенте
    {
        audioSCameraBilding.clip = enterCam;
        audioSCameraBilding.Play();
        deskopF.canExit = true;
        uiPonel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        mainCamera.depth = -1;
        listCamers[numberCameraActive].camInfo.depth = 1;
        camerIn = true;
    }

    public void ExitCameraNoise()
    {
        audioSCameraBilding.clip = exitCam;
        audioSCameraBilding.Play();
        camerIn = false;
    }

    public void ExitCamera() //используют анимации в ивенте
    {
        listCamers[numberCameraActive].camInfo.depth = -1;
        mainCamera.depth = 1;
    }

    public void ExitCameraOffPonel() //используют анимации в ивенте
    {
        mainCamera.transform.LookAt(gameObject.transform, Vector3.left);
        playerPosition.position = point.position;
        uiPonel.SetActive(false);
    }

    public void CamVoisPlay()
    {
        listAudio[numberCameraActive].Play();
        soundPlayed = true;
    }
}
