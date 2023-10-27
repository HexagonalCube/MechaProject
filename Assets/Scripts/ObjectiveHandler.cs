using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour
{
    [SerializeField] int ObjectiveTarget;
    public int ObjectiveCount;
    public bool clear;

    public void TryObjective()
    {
        if (ObjectiveCount == ObjectiveTarget)
        {
            clear = true;
        }
    }
}
