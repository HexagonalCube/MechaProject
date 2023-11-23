using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Updates the tile's sprites to the apropriate one at a distance
/// NEEDS TO BE SET UP W/ THE CURRENT PLAYER TO BE PAINTED
/// May cause lag, but it works
/// </summary>
public class DistanceRenderer : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Transform player;
    [SerializeField] SpriteRenderer spriteRd;
    [Header("Sprites")]
    [SerializeField] Sprite spriteFull;
    [SerializeField] Sprite spriteAlmostFull;
    [SerializeField] Sprite spriteMid;
    [SerializeField] Sprite spriteAlmostEmpty;
    [SerializeField] Sprite spriteEmpty;
    public bool explored = false;
    public float distanceMultiplier = 1;

    void Start() //Gets relevant variables
    {
        spriteRd = GetComponent<SpriteRenderer>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void UpdateSprites() //Updates sprite to relevant distance
    {
        explored = true; //Explored check for challenge
        float dist = (Vector2.Distance(player.position, transform.position)); //Distance to player
        switch (dist*distanceMultiplier) //Switches sprite, from player distance
        {
            case < 3:
                spriteRd.sprite=spriteFull;
            break;
            case < 4:
                spriteRd.sprite=spriteAlmostFull;
            break;
            case < 5:
                spriteRd.sprite=spriteMid;
            break;
            case < 6:
                spriteRd.sprite=spriteAlmostEmpty;
            break;
            case > 6 or 6:
                spriteRd.sprite=spriteEmpty;
            break;
        }
    }
}
