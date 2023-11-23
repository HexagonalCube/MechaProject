using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Level objectives & requirements
/// </summary>
public class ObjectiveHandler : MonoBehaviour
{
    [SerializeField] int ObjectiveTarget;
    public int ObjectiveCount;
    public bool clear;

    public void TryObjective() //sets clear flag if objective requirement is met
    {
        if (ObjectiveCount == ObjectiveTarget)
        {
            clear = true;
        }
    }
}
