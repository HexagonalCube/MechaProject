using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeScript : MonoBehaviour
{
    [SerializeField] ResourceSource[] resourcesTotal;
    [SerializeField] TurnHandler turnHandler;
    [SerializeField] TilesHandler tiles;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        resourcesTotal = FindObjectsOfType<ResourceSource>();
        level = SceneManager.GetActiveScene().buildIndex - 1;
    }
    public void CheckIfChallenge()
    {
        bool allResources = true;
        foreach (ResourceSource resourceSource in resourcesTotal)
        {
            if (resourceSource.active)
            {
                allResources = false;
            }
        }
        Debug.Log($"All Enemies Dead? {turnHandler.GetAllDead()}");
        if (turnHandler.GetAllDead())
        {
            SaveGame.SaveChallenge(level, 1);
        }
        Debug.Log($"All Tiles Explored? {tiles.GetTilesBool()}");
        if (tiles.GetTilesBool())
        {

        }
        Debug.Log($"All Enemies Alive? {turnHandler.GetAllAlive()}");
        if (turnHandler.GetAllAlive())
        {
            SaveGame.SaveChallenge(level,3);
        }
        Debug.Log($"All Resources Used? {allResources}");
        if (allResources)
        {
            SaveGame.SaveChallenge(level, 4);
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            CheckIfChallenge();
        }
    }
}
