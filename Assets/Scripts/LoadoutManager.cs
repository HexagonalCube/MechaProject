using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Class Selection manager, stores selected class and displays info
/// </summary>
public class LoadoutManager : MonoBehaviour
{
    public enum Class { Scout, Heavy, Sniper}
    public Class Loadout;
    [SerializeField] Button goButton;
    [SerializeField] bool selected = false;
    [SerializeField] TMP_Text text;
    [SerializeField] Button b1;
    [SerializeField] Button b2;
    [SerializeField] Button b3;
    [SerializeField] Image loadInfo;
    [SerializeField] Sprite loadType1;
    [SerializeField] Sprite loadType2;
    [SerializeField] Sprite loadType3;
    //private const string scoutDescription = "High FOV, Short Radar distance, Short Attack Distance";
    //private const string heavyDescription = "Normal FOV, Normal Radar distance, Normal Attack Distance";
    //private const string sniperDescription = "Narrow FOV, Long Radar distance, Long Attack distance";
    // Start is called before the first frame update
    void Start() //Checks to see if tutorial was completed to enable other class picks
    {
        goButton.interactable = false;
        if (!SaveGame.LoadLevel(1))
        {
            b1.interactable = true;
            b2.interactable = false;
            b3.interactable = false;
        }
        else
        {
            b1.interactable = true;
            b2.interactable = true;
            b3.interactable = true;
        }
    }
    public void LoadoutSelect(int loadout) //Recieves an int from loadout selection, saves selected class and updates displayed class info
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
        SaveGame.SaveSelectedClass(loadout);
    }
    void EnableGO(bool enable) // enables the go button after selecting a class
    {
        goButton.interactable = enable;
    }
    void UpdateClassInfo() //Updates class info on selected class type
    {
        if (selected)
        {
            switch (Loadout)
            {
                case Class.Scout:
                    loadInfo.sprite = loadType2;
                    break;
                case Class.Heavy:
                    loadInfo.sprite = loadType1;
                    break;
                case Class.Sniper:
                    loadInfo.sprite = loadType3;
                    break;
            }
        }
    }
}
