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
    void EndLevel()
    {
        victory.enabled = true;
        victory.sprite = victorySprite;
        StartCoroutine(Enumerator());
    }
    IEnumerator Enumerator()
    {
        DoorsAnimator a = FindFirstObjectByType(typeof(DoorsAnimator)).GameObject().GetComponent<DoorsAnimator>(); ;
        yield return new WaitForSecondsRealtime(1);
        a.CloseDoors();
        yield return new WaitForSecondsRealtime(1);
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
