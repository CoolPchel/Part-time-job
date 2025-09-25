using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 1f;
    private PauseButtons pauseScript;

    [SerializeField] AudioSource audioPlayerRobot;
    private ActivRobots robotsScrip;

    public GameObject interactionUI;
    // public TextMeshProUGUI interactionText;

    private void Start()
    {
        robotsScrip = FindObjectOfType<ActivRobots>();
        pauseScript = FindObjectOfType<PauseButtons>();
    }

    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                // interactionText.text = interactable.GetDescription();

                interactionUI.GetComponent<RectTransform>().localScale = new Vector3(0.18f, 0.18f, 0.18f);

                if(Input.GetKeyDown(KeyCode.E) && !pauseScript.pauseGame)
                {
                    if(hit.collider.tag == "CamMonitor")
                    {
                        DeskopFuncthion deskFScript = hit.collider.GetComponent<DeskopFuncthion>();
                        deskFScript.monitorOn = true;
                    }
                    
                    if(robotsScrip.isRobot)
                    {
                        audioPlayerRobot.Play();
                    }
                    interactable.Interact();
                }
            }
            else
            {
                interactionUI.GetComponent<RectTransform>().localScale = new Vector3(0.12f, 0.12f, 0.12f);
            }
        }
        else
        {
            interactionUI.GetComponent<RectTransform>().localScale = new Vector3(0.12f, 0.12f, 0.12f);
        }
    }
}