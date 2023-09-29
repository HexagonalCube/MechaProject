using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] bool DebugInfo = false;
    Rigidbody2D rb;

    void Start()
    {
        //Grabbing Components
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDrawGizmos()
    {
        //Draw where to check for space
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + (Vector3.up * 0.6f), transform.position + (Vector3.up * (gridSize - .5f)));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + (Vector3.right * 0.6f), transform.position + (Vector3.right * (gridSize - .5f)));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + (Vector3.down * 0.6f), transform.position + (Vector3.down * (gridSize - .5f)));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + (Vector3.left * 0.6f), transform.position + (Vector3.left * (gridSize - .5f)));
    }
    public bool MoveUp()
    {
        //Moves only if the square ahead is empty, Checks square with raycast on layer Solid.
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.up * 0.6f), transform.up, gridSize - .5f, mask))
        {
            if (DebugInfo){ Debug.Log("GridMoveSuccess"); }
            rb.position += Vector2.up * gridSize;
            return true;
        }
        else
        {
            if (DebugInfo) { Debug.LogWarning("GridMoveFail(U)"); }
            return false;
        }
    }
    public bool MoveDown()
    {
        //Moves only if the square ahead is empty, Checks square with raycast on layer Solid.
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.down * 0.6f), -transform.up, gridSize - .5f, mask))
        {
            if (DebugInfo) { Debug.Log("GridMoveSuccess"); }
            rb.position += Vector2.down * gridSize;
            return true;
        }
        else
        {
            if (DebugInfo) { Debug.LogWarning("GridMoveFail(D)"); }
            return false;
        }
    }
    public bool MoveLeft()
    {
        //Moves only if the square ahead is empty, Checks square with raycast on layer Solid.
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.left * 0.6f), -transform.right, gridSize - .5f, mask))
        {
            if (DebugInfo) { Debug.Log("GridMoveSuccess"); }
            rb.position += Vector2.left * gridSize;
            return true;
        }
        else
        {
            if (DebugInfo) { Debug.LogWarning("GridMoveFail(L)"); }
            return false;
        }
    }
    public bool MoveRight()
    {
        //Moves only if the square ahead is empty, Checks square with raycast on layer Solid.
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.right * 0.6f), transform.right, gridSize - .5f, mask))
        {
            if (DebugInfo) { Debug.Log("GridMoveSuccess"); }
            rb.position += Vector2.right * gridSize;
            return true;
        }
        else
        {
            if (DebugInfo) { Debug.LogWarning("GridMoveFail(R)"); }
            return false;
        }
    }
    public bool CheckRight()
    {
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.right * 0.6f), transform.right, gridSize - .5f, mask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckLeft()
    {
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.left * 0.6f), transform.right, gridSize - .5f, mask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckUp()
    {
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.up * 0.6f), transform.right, gridSize - .5f, mask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckDown()
    {
        LayerMask mask = LayerMask.GetMask("Solid");
        if (!Physics2D.Raycast(transform.position + (Vector3.down * 0.6f), transform.right, gridSize - .5f, mask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
