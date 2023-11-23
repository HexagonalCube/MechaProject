using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// When exiting a level when won, load Level select screen
/// </summary>
public class LoadLevelSelect : MonoBehaviour
{
    [SerializeField] MainMenuScript menuScript;

    void Start() //sets this object to not destroy itself
    {
        DontDestroyOnLoad(this.gameObject); 
    }
    private void OnLevelWasLoaded(int level) //On new Scene invoke MissionFirst
    {
        Invoke("MissonFirst", 0.3f);
    }

    void MissonFirst() //Sets the menu to load the level select when transition ends and destroys itself
    {
        menuScript = FindObjectOfType<MainMenuScript>().GetComponent<MainMenuScript>(); //BRUH, VS is buggin me about this fk off!!!
        if (menuScript != null)
        {
            menuScript.OnMissionSelect();
            Destroy(this.gameObject);
        }
    }

    public void GoToMenu() //Public go to menu button on Post-Game summary
    {
        StartCoroutine(MenuCountdown());
    }

    IEnumerator MenuCountdown() //Timed load menu, to allow for transition conditions
    {
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene(0);
    }
}
