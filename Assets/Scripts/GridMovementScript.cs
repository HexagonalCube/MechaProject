using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
/// <summary>
/// Gives general grid movement. Needs controller to call commands.
/// </summary>
public class GridMovementScript : MonoBehaviour
{
    [Header("Size in n^2 per cell, default 1x1")]
    [SerializeField] int gridSize = 1;
    //[Header("Speed in ms to move")]
    //[SerializeField] int gridSpeed = 10;
    [Header("Amount displayed in area")]
    [SerializeField] public int tileCount;
    Rigidbody2D rb;

    void Start()
    {
        //Grabbing Components
        rb = GetComponent<Rigidbody2D>();
        tileCount = CheckCollisions();
    }
    private void OnDrawGizmos()
    {
        //Draw where to check for space
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + (Vector3.up * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3.down * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (Vector3.left * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3.right * gridSize), new Vector3(gridSize, gridSize));
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
    //Still need to work out how to signal end of turn -\_(`.`)_/-, maybe put a call for every entity, or just signal on player controller
    public void MoveUp()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(0, transform.position.y + gridSize), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            Debug.Log("GridMoveSuccess");
            rb.position += Vector2.up * gridSize;
            tileCount = CheckCollisions();
        }
        else
        {
            Debug.LogError("GridMoveFail");
        }
    }
    public void MoveDown()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(0, transform.position.y - gridSize), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            Debug.Log("GridMoveSuccess");
            rb.position += Vector2.down * gridSize;
            tileCount = CheckCollisions();
        }
        else
        {
            Debug.LogError("GridMoveFail");
        }
    }
    public void MoveLeft()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(transform.position.x - gridSize, 0), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            Debug.Log("GridMoveSuccess");
            rb.position += Vector2.left * gridSize;
            tileCount = CheckCollisions();
        }
        else
        {
            Debug.LogError("GridMoveFail");
        }
    }
    public void MoveRight()
    {
        //Moves only if the square ahead is empty
        Collider2D[] colliders = new Collider2D[3];
        int num = Physics2D.OverlapBoxNonAlloc(new Vector2(transform.position.x + gridSize, 0), new Vector2(gridSize, gridSize), 0, colliders);
        if (num == 0)
        {
            Debug.Log("GridMoveSuccess");
            rb.position += Vector2.right * gridSize;
            tileCount = CheckCollisions();
        }
        else
        {
            Debug.LogError("GridMoveFail");
        }
    }
    int CheckCollisions()
    {
        Collider2D[] colliders = new Collider2D[8];
        int num = Physics2D.OverlapCircleNonAlloc(transform.position, 1.5f, colliders);
        return num;
    }
}
