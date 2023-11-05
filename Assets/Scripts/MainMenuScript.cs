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
    [SerializeField] MusicTransitionScript musicTrans;
    [SerializeField] MissionSelectScript mission;
    [SerializeField] DoorsAnimator animator;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        missionMenu.SetActive(false);
        configMenu.SetActive(false);
        confirmExit.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void OnMissionSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(true);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void OnLoadoutSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    public void OnConfigSelect()
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(true);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void OnCreditsSelect()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void OnMainMenuSelect()
    {
        mainMenu.SetActive(true);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void OnNextButtonPress()
    {
        mainMenu.SetActive(false);
        configMenu.SetActive(false);
        missionMenu.SetActive(false);
        loadoutMenu.SetActive(true);
        creditsMenu.SetActive(false);
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
