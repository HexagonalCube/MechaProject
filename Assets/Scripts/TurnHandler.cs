using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    [SerializeField] RandomMoveAI[] randomMoveAis;
    // Start is called before the first frame update
    void Start()
    {
        randomMoveAis = gameObject.GetComponentsInChildren<RandomMoveAI>();
        foreach(RandomMoveAI enemy in randomMoveAis)
        {
            Debug.Log($"Added{enemy.name} to the list");
        }
    }
    public void TurnEnd()
    {
        foreach(RandomMoveAI enemy in randomMoveAis)
        {
            enemy.MoveRNG();
        }
    } 
}
