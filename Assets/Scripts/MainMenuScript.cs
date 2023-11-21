using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Start()
    {
        StartCoroutine(LoadDefault());
    }
    public void OnMissionSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(true);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnLoadoutSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnConfigSelect()
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(true);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnCreditsSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(true);
        challengesMenu.SetActive(false);
    }
    public void OnMainMenuSelect()
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnChallengesSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(true);
    }
    public void OnNextButtonPress()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(false);
        challengesMenu.SetActive(false);
    }
    public void OnGoButtonPress()
    {
        animator.CloseDoors();
        musicTrans.Fade();
        StartCoroutine(Transition());
    }
    private IEnumerator Transition()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene(mission.selected + 1);
    }
    public void OnExitButtonPress()
    {
        confirmExit.SetActive(true);
    }
    public void OnBackButtonPress()
    {
        confirmExit.SetActive(false);
    }
    public void OnConfirmExitButtonPress()
    {
        Application.Quit();
    }
    IEnumerator LoadDefault()
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = true;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Screen.fullScreen = false;
        }
    }
}
