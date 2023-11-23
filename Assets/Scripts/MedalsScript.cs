using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Checks each challange completion and appplies relevant graphics
/// </summary>
public class MedalsScript : MonoBehaviour
{
    [SerializeField] GameObject[] medals = new GameObject[12]; //Medals in UI
    int row = 1;
    int col = 0;

    void Start() //Gets if challenge completed for each medal in a row/collum list (lvl/challenge)
    {
        foreach (GameObject medal in medals)
        {
            if (col < 4)
            {
                col++;
            }
            else
            {
                col = 1;
                row++;
            }
            Debug.Log($"{row} | {col}");
            medal.GetComponent<Image>().enabled = SaveGame.LoadChallenge(row,col);
        }
    }
}
