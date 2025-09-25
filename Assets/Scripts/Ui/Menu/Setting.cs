using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Setting : MonoBehaviour
{
    public TMP_Dropdown extensionDropdown;
    public TMP_Dropdown graphicsDropdown;

    Resolution[] resolutions;

    void Start()
    {
        extensionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions; 
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }   

        extensionDropdown.AddOptions(options);
        extensionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SeveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", graphicsDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", extensionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            graphicsDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            graphicsDropdown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            extensionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            extensionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullScreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        else
            Screen.fullScreen = true;    
    }
}
