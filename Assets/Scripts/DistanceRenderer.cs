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
    // Start is called before the first frame update
    void Start()
    {
        spriteRd = GetComponent<SpriteRenderer>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void UpdateSprites()
    {
        float dist = (Vector2.Distance(player.position, transform.position));
        switch (dist)
        {
            case < 2.5f:
                spriteRd.sprite=spriteFull;
            break;
            case < 3.5f:
                spriteRd.sprite=spriteAlmostFull;
            break;
            case < 4.5f:
                spriteRd.sprite=spriteMid;
            break;
            case < 5.5f:
                spriteRd.sprite=spriteAlmostEmpty;
            break;
            case > 5.5f or 5.5f:
                spriteRd.sprite=spriteEmpty;
            break;
        }
    }
}
