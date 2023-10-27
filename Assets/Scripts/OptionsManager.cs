using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Resolution[] fullScreenResolutionsAvailable;
    [SerializeField] List<string> fullScreenResolutionList;
    [SerializeField] TMP_Dropdown resolutionSelector;
    [SerializeField] bool fullScreen = true;
    [SerializeField] Resolution selectedResolution;
    private void Start()
    {
        fullScreenResolutionsAvailable = Screen.resolutions;
        GetResolutions();
        fullScreen = SaveGame.LoadFullscreen();
        selectedResolution = fullScreenResolutionsAvailable[SaveGame.LoadResolution()];
        UpdateResolution();
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
        resolutionSelector.SetValueWithoutNotify(fullScreenResolutionList.Count);
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
        SaveGame.SaveResolution(res);
        UpdateResolution();
    }
    void UpdateResolution()
    {
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreen);
    }
    public void SetVolume(float vol)
    {
        SaveGame.SaveVolume(vol);
    }
}
