using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutManager : MonoBehaviour
{
    public enum Class { Scout, Heavy, Sniper}
    public Class Loadout;
    [SerializeField] Button goButton;
    [SerializeField] bool selected = false;
    [SerializeField] TMP_Text text;
    private const string scoutDescription = "High FOV, Short Radar distance, Short Attack Distance";
    private const string heavyDescription = "Normal FOV, Normal Radar distance, Normal Attack Distance";
    private const string sniperDescription = "Narrow FOV, Long Radar distance, Long Attack distance";
    // Start is called before the first frame update
    void Start()
    {
        goButton.interactable = false;
    }
    public void LoadoutSelect(int loadout)
    {
        selected = true;
        switch (loadout)
        {
            case 0:
                Loadout = Class.Heavy; break;
            case 1:
                Loadout = Class.Scout; break;
            case 2:
                Loadout = Class.Sniper; break;
        }
        UpdateClassInfo();
        EnableGO(selected);
    }
    void EnableGO(bool enable)
    {
        goButton.interactable = enable;
    }
    void UpdateClassInfo()
    {
        if (selected)
        {
            switch (Loadout)
            {
                case Class.Scout:
                    text.SetText(scoutDescription);
                    break;
                case Class.Heavy:
                    text.SetText(heavyDescription);
                    break;
                case Class.Sniper:
                    text.SetText(sniperDescription);
                    break;
            }
        }
        else
        {

        }
    }
}
