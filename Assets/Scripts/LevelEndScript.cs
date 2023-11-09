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
    private void Start()
    {
        //Search once for player and apply the relevant variables;
        GameObject player = FindFirstObjectByType<PlayerController>().gameObject;
        music = player.GetComponentInChildren<MusicComposer>();
        musTrans = player.GetComponentInChildren<MusicTransitionScript>();
    }
    void EndLevel()
    {
        victory.enabled = true;
        victory.sprite = victorySprite;
        StartCoroutine(Enumerator());
        SaveGame.SaveLevel(true,SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitLevel()
    {
        StartCoroutine(Enumerator());
    }
    IEnumerator Enumerator()
    {
        music.scheduleEnd = true;
        DoorsAnimator a = FindFirstObjectByType(typeof(DoorsAnimator)).GameObject().GetComponent<DoorsAnimator>(); ;
        yield return new WaitForSecondsRealtime(1);
        musTrans.Fade();
        a.CloseDoors();
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && count.clear)
        {
            EndLevel();
        }
    }
}
