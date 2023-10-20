using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour
{
    public int level;

    public void EndLevel()
    {
        StartCoroutine(Enumerator());
    }
    IEnumerator Enumerator()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
