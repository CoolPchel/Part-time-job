using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLocation : MonoBehaviour
{
    [SerializeField] List<GameObject> chapterLocation;
    [SerializeField] StartDoor startDoor;
    [SerializeField] List<Wandering> npcScript;
    [SerializeField] ButonActivCart scriptBAC;
    [SerializeField] List<GameObject> generators;
    private int randomNumber;

    private void Awake()
    {   randomNumber = Random.Range(0, generators.Count);
        generators[randomNumber].SetActive(true);
        chapterLocation[1].SetActive(false);
        startDoor.openStartDoor = false;
    }

    private void Update()
    {
        if(scriptBAC.nextChapter)
        {
            chapterLocation[1].SetActive(true);
            scriptBAC.nextChapter = false;
            startDoor.openStartDoor = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            startDoor.openStartDoor = false;
            for(int i = 0; i < npcScript.Count; i++)
            {
                npcScript[i].startGameTime = true;
            }
            chapterLocation[0].SetActive(false);
        }
    }
}
