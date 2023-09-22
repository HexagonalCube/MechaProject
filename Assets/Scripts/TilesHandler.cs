using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesHandler : MonoBehaviour
{
    [SerializeField] DistanceRenderer[] tiles;

    void Start()
    {
        //Gathers tiles in a list and logs it's location
        tiles = gameObject.GetComponentsInChildren<DistanceRenderer>();
        SignalTiles();
    }
    public void SignalTiles()
    {
        //Signals every tile in the list to update
        foreach (DistanceRenderer tile in tiles)
        {
            tile.UpdateSprites();
        }
    }
}
