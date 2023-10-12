using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField] AiComponent[] aiComponents;
    public bool spotted = false;
    // Start is called before the first frame update
    void Start()
    {
        aiComponents = gameObject.GetComponentsInChildren<AiComponent>();
        foreach(AiComponent enemy in aiComponents)
        {
            Debug.Log($"Added{enemy.name} to the list");
        }
    }
    public void TurnEnd()
    {
        foreach(AiComponent ai in aiComponents)
        {
            ai.TryMove();
            if(ai.hunting) { spotted = true; }
        }
    } 
}
