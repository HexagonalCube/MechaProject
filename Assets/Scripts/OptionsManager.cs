using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// Player Options Script
/// </summary>
public class OptionsManager : MonoBehaviour
{
    [SerializeField] Resolution[] fullScreenResolutionsAvailable;
    [SerializeField] List<string> fullScreenResolutionList;
    [SerializeField] TMP_Dropdown resolutionSelector;
    [SerializeField] bool fullScreen = true;
    [SerializeField] Resolution selectedResolution;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer masterVolume;
    private void Start() //Gets Fisrt-Time and previously set options
    {
        fullScreenResolutionsAvailable = Screen.resolutions;
        GetResolutions();
        fullScreen = SaveGame.LoadFullscreen();
        selectedResolution = fullScreenResolutionsAvailable[SaveGame.LoadResolutionIndex()];
        Debug.Log($"Previously set resolution {SaveGame.LoadResolutionIndex()}");
        UpdateResolution();
        LoadVolume();
    }
    void GetResolutions() //Gets all available resolutions, & sets player default to highest
    {
        for (int i = 0; i < fullScreenResolutionsAvailable.Length; i++)
        {
            //float w = fullScreenResolutionsAvailable[i].width;
            //float h = fullScreenResolutionsAvailable[i].height;
            fullScreenResolutionList.Add($"{fullScreenResolutionsAvailable[i].width} x {fullScreenResolutionsAvailable[i].height} ({fullScreenResolutionsAvailable[i].refreshRate}Hz)");
        }
        resolutionSelector.AddOptions(fullScreenResolutionList);
        resolutionSelector.SetValueWithoutNotify(SaveGame.LoadResolutionIndex());
        if (PlayerPrefs.GetInt("FRESH",0) == 0)
        {
            resolutionSelector.SetValueWithoutNotify(fullScreenResolutionList.Count-1);
            SetResolution(fullScreenResolutionList.Count-1);
        }
    }
    public void MakeFullscreen(bool fs) //Toggles & saves fullscreen
    {
        fullScreen = fs;
        SaveGame.SaveFullscreen(fs);
        UpdateResolution();
    }
    public void SetResolution(int res) //Sets resolution in list Index
    {
        selectedResolution = fullScreenResolutionsAvailable[res];
        SaveGame.SaveResolutionIndex(res);
        PlayerPrefs.SetInt("FRESH",1);
        Debug.Log($"Resolution Index Set {res}");
        UpdateResolution();
    }
    void UpdateResolution() //Updates screen resolution
    {
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreen, selectedResolution.refreshRate);
    }
    public void SetVolume(float vol) //saves selected volume & sets volume to log10 scale
    {
        SaveGame.SaveVolume(vol);
        float convertedVolume = Mathf.Log10(vol) * 20;
        masterVolume.SetFloat("MasterVolume", convertedVolume);
    }
    void LoadVolume() //Loads saved volume & converts to log10 scale
    {
        volumeSlider.SetValueWithoutNotify(SaveGame.LoadVolume());
        float convertedVolume = Mathf.Log10(SaveGame.LoadVolume()) * 20;
        masterVolume.SetFloat("MasterVolume",convertedVolume);
        Debug.Log($"VolumeLoaded {SaveGame.LoadVolume()}");
    }
}
