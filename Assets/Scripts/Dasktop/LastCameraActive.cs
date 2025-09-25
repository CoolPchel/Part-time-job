using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCameraActive : MonoBehaviour
{
    [SerializeField] Transform camLastActive;
    [SerializeField] List<Transform> listCamersT;
    public int numberLastActiveCam;

    public void NextCam()
    {
        camLastActive.position = listCamersT[numberLastActiveCam].position;
        camLastActive.rotation = listCamersT[numberLastActiveCam].rotation;
    }
}
