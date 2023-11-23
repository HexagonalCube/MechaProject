using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Signals to enemies end of turn, and holds their instances
/// </summary>
public class TurnHandler : MonoBehaviour
{
    [SerializeField] AiComponent[] aiComponents;
    [SerializeField] bool[] hunting; //if any are aggro
    public bool spotted = false;

    void Start() //Gets Variables values
    {
        aiComponents = gameObject.GetComponentsInChildren<AiComponent>();
        foreach(AiComponent enemy in aiComponents)
        {
            Debug.Log($"Added{enemy.name} to the list");
        }
        hunting = new bool[aiComponents.Length];
        for(int i = 0; i < aiComponents.Length; i++)
        {
            hunting[i] = aiComponents[i].hunting;
        }
    }
    public void TurnEnd() //Signals end of turn
    {
        foreach(AiComponent ai in aiComponents)
        {
            if ( ai != null )
            {
                ai.TryMove();
            }
        }
        for (int i = 0; i < aiComponents.Length; i++)
        {
            hunting[i] = aiComponents[i].hunting;
        }
        if (hunting.Contains(true)) { spotted = true; }
        else { spotted = false; }
    } 
    public bool UpdateList() //Updates the hunting list
    {
        for (int i = 0; i < aiComponents.Length; i++)
        {
            hunting[i] = aiComponents[i].hunting;
        }
        return true;
    }
    public bool GetAllDead() //Check if all enemies are dead
    {
        bool result = true;
        foreach (AiComponent enemy in aiComponents)
        {
            if (enemy.enabled) //if any alive return false
            {
                result = false;
            }
        }
        return result;
    }
    public bool GetAllAlive() //Check if all enemies are alive
    {
        bool result = true;
        foreach (AiComponent enemy in aiComponents)
        {
            if (!enemy.enabled) //if any dead return false
            {
                result = false;
            }
        }
        return result;
    }
    //public void Spotting(bool spot)
    //{
    //    spotted = spot;
    //}
}
