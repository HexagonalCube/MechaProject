using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TilesHandler : MonoBehaviour
{
    public DistanceRenderer[] tiles;

    void Start()
    {
        //Gathers tiles in a list and logs it's location
        tiles = gameObject.GetComponentsInChildren<DistanceRenderer>();
    }
    public bool GetTilesBool()
    {
        bool result = true;
        foreach (DistanceRenderer tile in tiles)
        {
            if (!tile.explored)
            {
                result = false;
            }
        }
        return result;
    }
}
