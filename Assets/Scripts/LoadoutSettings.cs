using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Applies class loadout atributes to player
/// </summary>
public class LoadoutSettings : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerFOV;
    [SerializeField] Sprite fovSmall;
    [SerializeField] Sprite fovMedium;
    [SerializeField] Sprite fovLarge;
    [SerializeField] SpaceRenderer spaceRenderer;
    [SerializeField] CursorScript cursor;

    private void Start() //Applies relevant class loadout atributes to the player
    {
        int selectedClass = SaveGame.LoadSelectedClass();
        switch (selectedClass)
        {
            case 0:
                playerFOV.sprite = fovMedium;
                spaceRenderer.renderDistance = 0.95f;
                cursor.range = 4;
                break;
            case 1:
                playerFOV.sprite = fovLarge;
                spaceRenderer.renderDistance = 1.10f;
                cursor.range = 3;
                break;
            case 2:
                playerFOV.sprite = fovSmall;
                spaceRenderer.renderDistance = 0.75f;
                cursor.range = 6;
                break;
        }
    }
}
