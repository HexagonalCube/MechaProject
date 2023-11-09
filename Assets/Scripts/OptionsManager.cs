using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Resolution[] fullScreenResolutionsAvailable;
    [SerializeField] List<string> fullScreenResolutionList;
    [SerializeField] TMP_Dropdown resolutionSelector;
    [SerializeField] bool fullScreen = true;
    [SerializeField] Resolution selectedResolution;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer masterVolume;
    private void Start()
    {
        fullScreenResolutionsAvailable = Screen.resolutions;
        GetResolutions();
        fullScreen = SaveGame.LoadFullscreen();
        selectedResolution = fullScreenResolutionsAvailable[SaveGame.LoadResolutionIndex()];
        Debug.Log($"Previously set resolution {SaveGame.LoadResolutionIndex()}");
        UpdateResolution();
        LoadVolume();
    }
    void GetResolutions()
    {
        for (int i = 0; i < fullScreenResolutionsAvailable.Length; i++)
        {
            float w = fullScreenResolutionsAvailable[i].width;
            float h = fullScreenResolutionsAvailable[i].height;
            fullScreenResolutionList.Add($"{fullScreenResolutionsAvailable[i].width} x {fullScreenResolutionsAvailable[i].height} ({fullScreenResolutionsAvailable[i].refreshRate}Hz)");
        }
        resolutionSelector.AddOptions(fullScreenResolutionList);
        resolutionSelector.SetValueWithoutNotify(SaveGame.LoadResolutionIndex());
    }
    public void MakeFullscreen(bool fs)
    {
        fullScreen = fs;
        SaveGame.SaveFullscreen(fs);
        UpdateResolution();
    }
    public void SetResolution(int res)
    {
        selectedResolution = fullScreenResolutionsAvailable[res];
        SaveGame.SaveResolutionIndex(res);
        Debug.Log($"Resolution Index Set {res}");
        UpdateResolution();
    }
    void UpdateResolution()
    {
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreen, selectedResolution.refreshRate);
    }
    public void SetVolume(float vol)
    {
        SaveGame.SaveVolume(vol);
        float convertedVolume = Mathf.Log10(vol) * 20;
        masterVolume.SetFloat("MasterVolume", convertedVolume);
    }
    void LoadVolume()
    {
        volumeSlider.SetValueWithoutNotify(SaveGame.LoadVolume());
        float convertedVolume = Mathf.Log10(SaveGame.LoadVolume()) * 20;
        masterVolume.SetFloat("MasterVolume",convertedVolume);
    }
}
