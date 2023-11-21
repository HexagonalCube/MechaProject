using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalsScript : MonoBehaviour
{
    [SerializeField] GameObject[] medals = new GameObject[12];
    int row = 1;
    int col = 0;
    // Start is called before the first frame update
    void Start()
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
            medal.GetComponent<Image>().enabled = SaveGame.LoadChallenge(row,col);
        }
    }
}
