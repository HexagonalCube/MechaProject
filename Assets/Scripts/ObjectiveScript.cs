using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dedicated objective script to level objectives
/// </summary>
public class ObjectiveScript : MonoBehaviour
{
    [SerializeField] ObjectiveHandler handler;
    public void AddObjective() //adds to total objective count & disables itself
    {
        if (handler != null)
        {
            handler.ObjectiveCount++;
            handler.TryObjective();
        }
        this.gameObject.SetActive(false);
    }
}
