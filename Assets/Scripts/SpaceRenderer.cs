using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceRenderer : MonoBehaviour
{
    [SerializeField] Collider2D[] objs;
    [SerializeField] LayerMask layer;
    [SerializeField] float renderDistance = 1;
    private void Start()
    {
        layer = LayerMask.GetMask("Solid");
    }
    private void FixedUpdate()
    {
        objs = new Collider2D[500];
        Physics2D.OverlapBoxNonAlloc(transform.position, new Vector2(20, 20), 0, objs,layer);
        foreach (Collider2D obj in objs)
        {
            if (obj != null)
            {
                DistanceRenderer render = obj.gameObject.GetComponent<DistanceRenderer>();
                render.distanceMultiplier = renderDistance;
                render.UpdateSprites();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(20, 20));
    }
}
