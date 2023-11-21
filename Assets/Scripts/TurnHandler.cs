using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField] AiComponent[] aiComponents;
    [SerializeField] bool[] hunting;
    public bool spotted = false;
    // Start is called before the first frame update
    void Start()
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
    public void TurnEnd()
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
    public bool UpdateList()
    {
        for (int i = 0; i < aiComponents.Length; i++)
        {
            hunting[i] = aiComponents[i].hunting;
        }
        return true;
    }
    public bool GetAllDead()
    {
        bool result = true;
        foreach (AiComponent enemy in aiComponents)
        {
            if (enemy.enabled)
            {
                result = false;
            }
        }
        return result;
    }
    public bool GetAllAlive()
    {
        bool result = true;
        foreach (AiComponent enemy in aiComponents)
        {
            if (!enemy.enabled)
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
