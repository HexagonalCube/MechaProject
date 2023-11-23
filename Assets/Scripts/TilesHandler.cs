using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// Holds all tiles in list, Used mainly to check challenges
/// </summary>
public class TilesHandler : MonoBehaviour
{
    public DistanceRenderer[] tiles;

    void Start() //Gets all tiles
    {
        //Gathers tiles in a list and logs it's location
        tiles = gameObject.GetComponentsInChildren<DistanceRenderer>();
    }
    public bool GetTilesBool() //Checks if all tiles explored
    {
        bool result = true;
        foreach (DistanceRenderer tile in tiles)
        {
            if (!tile.explored) //if any arent explored, return false
            {
                result = false;
            }
        }
        return result;
    }
}
