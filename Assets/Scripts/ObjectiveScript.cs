using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    [SerializeField] ObjectiveHandler handler;
    public void AddObjective()
    {
        if (handler != null)
        {
            handler.ObjectiveCount++;
            handler.TryObjective();
        }
        this.gameObject.SetActive(false);
    }
}
