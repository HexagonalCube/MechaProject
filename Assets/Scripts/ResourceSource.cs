using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Resource script used to give the player more ammo in a level
/// </summary>
public class ResourceSource : MonoBehaviour
{
    [SerializeField] int resources; //How many resources in this source
    public bool active = true; //Is untouched
    [SerializeField] SpriteRenderer sprite;
    private void Start() //Gets default variables
    {
        sprite = GetComponent<SpriteRenderer>();
        if (!active) { sprite.color = Color.gray; } //Used to give more visual cues since having it be there without resources doesnt add much to the level, UNUSED
    }
    public int GetResources() //When cursor tries to get resources from component
    {
        if (active) //Give ammo back and turn self gray & disabled
        {
            sprite.color = Color.gray;
            int res = resources;
            resources = 0;
            active = false;
            return res;
        }
        else
        {
            return 0; //Return nothing if disabled
        }
    }
}
