using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtons : MonoBehaviour
{
    private AudioSource audioButtons;

    private void Awake()
    {
        audioButtons = GetComponent<AudioSource>();
    }

    public void Clik()
    {
        audioButtons.Play();
    }
}
