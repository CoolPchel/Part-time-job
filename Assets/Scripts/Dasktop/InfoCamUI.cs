using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCamUI : MonoBehaviour
{
    [SerializeField] Animator noiseAm;
    public Camera camInfo;
    private CamersInBuilding deskopCScript;
    [SerializeField] int numberCamera;

    private void Start()
    {
        deskopCScript = FindObjectOfType<CamersInBuilding>();
    }

    public void ClickCam()
    {
        noiseAm.SetTrigger("SwithCam");
        deskopCScript.numberCameraActive = numberCamera;
        deskopCScript.ActiveCamera();
    }
}
