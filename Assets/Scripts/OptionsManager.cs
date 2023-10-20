using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Resolution[] fullScreenResolutionsAvailable;
    [SerializeField] List<string> fullScreenResolutionList;
    [SerializeField] TMP_Dropdown resolutionSelector;
    [SerializeField] bool fullScreen;
    [SerializeField] Resolution selectedResolution;
    private void Start()
    {
        fullScreenResolutionsAvailable = Screen.resolutions;
        GetResolutions();
    }
    void GetResolutions()
    {
        for (int i = 0; i < fullScreenResolutionsAvailable.Length; i++)
        {
            fullScreenResolutionList.Add($"{fullScreenResolutionsAvailable[i].width} x {fullScreenResolutionsAvailable[i].height}");
        }
        resolutionSelector.AddOptions(fullScreenResolutionList);
        resolutionSelector.SetValueWithoutNotify(fullScreenResolutionList.Count);
    }
    public void MakeFullscreen(bool fs)
    {
        fullScreen = fs;
        UpdateResolution();
    }
    public void SetResolution(int res)
    {
        selectedResolution = fullScreenResolutionsAvailable[res];
        UpdateResolution();
    }
    void UpdateResolution()
    {
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreen);
    }
}
