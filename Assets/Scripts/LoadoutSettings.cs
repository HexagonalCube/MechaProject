using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutSettings : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerFOV;
    [SerializeField] Sprite fovSmall;
    [SerializeField] Sprite fovMedium;
    [SerializeField] Sprite fovLarge;
    [SerializeField] SpaceRenderer spaceRenderer;
    [SerializeField] CursorScript cursor;

    private void Start()
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
                spaceRenderer.renderDistance = 0.75f;
                cursor.range = 3;
                break;
            case 2:
                playerFOV.sprite = fovSmall;
                spaceRenderer.renderDistance = 1.20f;
                cursor.range = 6;
                break;
        }
    }
}
