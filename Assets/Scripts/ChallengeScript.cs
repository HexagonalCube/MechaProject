using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeScript : MonoBehaviour
{
    [SerializeField] ResourceSource[] resourcesTotal; //Resources list on level
    [SerializeField] TurnHandler turnHandler; //enemies on level
    [SerializeField] TilesHandler tiles; //tiles on level
    [SerializeField] int level; //wich level

    void Start() //assign objects to variables
    {
        resourcesTotal = FindObjectsOfType<ResourceSource>();
        level = SceneManager.GetActiveScene().buildIndex - 1;
    }
    public void CheckIfChallenge() //Checks if completed a challenge
    {
        bool allResources = true;
        foreach (ResourceSource resourceSource in resourcesTotal) //if any resource is unused, cancel save challenge
        {
            if (resourceSource.active)
            {
                allResources = false;
            }
        }
        Debug.Log($"All Enemies Dead? {turnHandler.GetAllDead()}");
        if (turnHandler.GetAllDead()) //if turnhandler says theyre all dead
        {
            SaveGame.SaveChallenge(level, 1); //save all dead & level
        }
        Debug.Log($"All Tiles Explored? {tiles.GetTilesBool()}");
        if (tiles.GetTilesBool()) //if tileshandler says theyre all explored
        {
            SaveGame.SaveChallenge(level, 2); //save all tiles searched & level
        }
        Debug.Log($"All Enemies Alive? {turnHandler.GetAllAlive()}");
        if (turnHandler.GetAllAlive()) //if turnhandler says theyre all alive
        {
            SaveGame.SaveChallenge(level,3); //save all alive & level
        }
        Debug.Log($"All Resources Used? {allResources}");
        if (allResources) //if start bool is still true
        {
            SaveGame.SaveChallenge(level, 4); //save all resources used & level
        }
    }
    //private void Update() // Debug
    //{
    //    if (Input.GetKeyUp(KeyCode.O))
    //    {
    //        CheckIfChallenge();
    //    }
    //}
}
