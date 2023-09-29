using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField] AiComponent[] aiComponents;
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
        }
    } 
}
