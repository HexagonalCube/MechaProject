using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndScript : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] Image victory;
    [SerializeField] Sprite victorySprite;
    [SerializeField] ObjectiveHandler count;
    [SerializeField] MusicComposer music;
    [SerializeField] MusicTransitionScript musTrans;
    [SerializeField] ChallengeScript challenge;
    private void Start() //get variables
    {
        //Search once for player and apply the relevant variables;
        GameObject player = FindFirstObjectByType<PlayerController>().gameObject;
        music = player.GetComponentInChildren<MusicComposer>();
        musTrans = player.GetComponentInChildren<MusicTransitionScript>();
    }
    void EndLevel() //Ends Level and saves completion
    {
        victory.enabled = true;
        victory.sprite = victorySprite;
        StartCoroutine(QuitWin());
        SaveGame.SaveLevel(true,SceneManager.GetActiveScene().buildIndex);
        challenge.CheckIfChallenge();
    }
    public void QuitLevel() //Public quit action
    {
        StartCoroutine(QuitLose());
    }
    IEnumerator QuitWin() //Timed win Animations and transitions
    {
        music.scheduleEnd = true;
        DoorsAnimator a = FindFirstObjectByType(typeof(DoorsAnimator)).GameObject().GetComponent<DoorsAnimator>(); ;
        yield return new WaitForSecondsRealtime(1);
        musTrans.Fade();
        a.CloseDoors();
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("Post-Game Awards");
    }
    IEnumerator QuitLose() //Timed lose Animations and transitions
    {
        music.scheduleEnd = true;
        DoorsAnimator a = FindFirstObjectByType(typeof(DoorsAnimator)).GameObject().GetComponent<DoorsAnimator>(); ;
        yield return new WaitForSecondsRealtime(1);
        musTrans.Fade();
        a.CloseDoors();
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision) //Quits when on extraction point & has all objectives
    {
        if (collision.CompareTag("Player") && count.clear)
        {
            EndLevel();
        }
    }
}
