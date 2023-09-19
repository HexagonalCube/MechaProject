using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GridMovementScript : MonoBehaviour
{
    [Header("Size in n^2 per cell, default 8x8")]
    [SerializeField] int gridSize = 8;
    [Header("Speed in ms to move")]
    [SerializeField] int gridSpeed = 10;
    [Header("Ammount displayed in area")]
    [SerializeField] int tileCount = 8;
    Rigidbody2D rb;

    void Start()
    {
        //Grabbing Components
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDrawGizmos()
    {
        //Draw where to check for space
        Gizmos.DrawCube(transform.position + (Vector3.up * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.DrawCube(transform.position + (Vector3.down * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.DrawCube(transform.position + (Vector3.left * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.DrawCube(transform.position + (Vector3.right * gridSize), new Vector3(gridSize, gridSize));
    }
    //Still need to work out how to signal end of turn -\_(`.`)_/-, maybe put a call for every entity, or just signal on player controller
    public void MoveUp()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(0, transform.position.y + gridSize), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            rb.position += Vector2.up * gridSize;
        }
    }
    public void MoveDown()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(0, transform.position.y - gridSize), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            rb.position += Vector2.down * gridSize;
        }
    }
    public void MoveLeft()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(transform.position.x - gridSize, 0), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            rb.position += Vector2.left * gridSize;
        }
    }
    public void MoveRight()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(transform.position.x + gridSize, 0), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            rb.position += Vector2.left * gridSize;
        }
    }
}
