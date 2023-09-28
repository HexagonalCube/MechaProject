using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject configMenu;
    [SerializeField] GameObject missionMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        missionMenu.SetActive(false);
        configMenu.SetActive(false);
    }
    public void OnMissionSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(true);
    }
    public void OnConfigSelect()
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(true);
        missionMenu.SetActive(false);
    }
    public void OnMainMenuSelect()
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
    }
    public void OnGoButtonPress()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExitButtonPress()
    {
        Application.Quit();
    }
}
