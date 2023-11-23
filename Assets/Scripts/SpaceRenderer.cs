using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Gets every tile in view distance to player & tells those tiles to update their sprites to match their distance
/// </summary>
public class SpaceRenderer : MonoBehaviour
{
    [SerializeField] Collider2D[] objs; //Tiles
    [SerializeField] LayerMask layer;
    public float renderDistance = 1;
    private void Start() //Sets the mask of what to check for
    {
        layer = LayerMask.GetMask("Solid");
    }
    private void FixedUpdate() //Updates the sprites whitin the view distance to the required values & atributes
    {
        objs = new Collider2D[500]; //Clears all tiles and establishes a limit
        Physics2D.OverlapBoxNonAlloc(transform.position, new Vector2(20, 20), 0, objs,layer);
        foreach (Collider2D obj in objs)
        {
            if (obj != null)
            {
                DistanceRenderer render = obj.gameObject.GetComponent<DistanceRenderer>(); //gets renderer from object
                render.distanceMultiplier = renderDistance; //Updates their rederMultiplier given by the class
                render.UpdateSprites(); //Updates their sprites
            }
        }
    }
    private void OnDrawGizmos() //Draws the view box
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(20, 20));
    }
}
