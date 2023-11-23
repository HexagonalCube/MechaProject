using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Main Menu controller script
/// </summary>
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject configMenu;
    [SerializeField] GameObject missionMenu;
    [SerializeField] GameObject loadoutMenu;
    [SerializeField] GameObject confirmExit;
    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject transition;
    [SerializeField] GameObject challengesMenu;
    [SerializeField] MusicTransitionScript musicTrans;
    [SerializeField] MissionSelectScript mission;
    [SerializeField] DoorsAnimator animator;
    void Start() //Loads Default State & values on start
    {
        StartCoroutine(LoadDefault());
    }
    public void OnMissionSelect() //Loads Mission Select screen
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(true);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnLoadoutSelect() //Loads Loadout Select screen
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnConfigSelect()  //Loads Config screen
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(true);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnCreditsSelect()  //Loads Credits screen
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(true);
        challengesMenu.SetActive(false);
    }
    public void OnMainMenuSelect()  //Loads Menu screen
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnChallengesSelect() //Loads Challenges/Medals screen
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(true);
    }
    public void OnNextButtonPress()  //Loads Loadout Select screen
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnGoButtonPress()  //Loads Selected level and plays transition animations
    {
        animator.CloseDoors();
        musicTrans.Fade();
        StartCoroutine(Transition());
    }
    private IEnumerator Transition() //transition timer to let animation play
    {
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene(mission.selected + 1);
    }
    public void OnExitButtonPress() //Gets if player wants to quit
    {
        confirmExit.SetActive(true);
    }
    public void OnBackButtonPress() //If player doesnt want to quit
    {
        confirmExit.SetActive(false);
    }
    public void OnConfirmExitButtonPress() //If player quits
    {
        Application.Quit();
    }
    IEnumerator LoadDefault() //Gives each screen time to set game values and loads default menu screen
    {
        mainMenu.SetActive(true);
        missionMenu.SetActive(true);
        configMenu.SetActive(true);
        confirmExit.SetActive(true);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(true);
        challengesMenu.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mainMenu.SetActive(true);
        missionMenu.SetActive(false);
        configMenu.SetActive(false);
        confirmExit.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    //private void Update() //debug
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        Screen.fullScreen = true;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Backspace))
    //    {
    //        Screen.fullScreen = false;
    //    }
    //}
}
