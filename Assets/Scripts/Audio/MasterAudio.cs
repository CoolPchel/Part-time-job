using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterAudio : MonoBehaviour
{
    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] string name;
    [SerializeField] Slider sliderVolum;
    public float volumeSave = 1;

    public void ChangeVolumeMaster(float volume)
    {
        mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        volumeSave = volume;
    }

    public void ChangeVolumeMusik(float volume)
    {
        mixer.audioMixer.SetFloat("Musik", Mathf.Lerp(-80, 0, volume));
        volumeSave = volume;
    }

    public void ChangeVolumeSound(float volume)
    {
        mixer.audioMixer.SetFloat("Sound", Mathf.Lerp(-80, 0, volume));
        volumeSave = volume;
    }

    public void SaveAudio()
    {
        PlayerPrefs.SetFloat(name, volumeSave);
    }

    public void LoadAudio()
    {
        if((PlayerPrefs.HasKey(name)))
        {
            volumeSave = PlayerPrefs.GetFloat(name);
            sliderVolum.value = volumeSave;
        }
    }
}
