using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float range = 5;
    [SerializeField] LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<GridMovementScript>();
    }
    public void CursorChangeActive(bool active)
    {
        transform.position = player.transform.transform.position;
        sprite.enabled = active;
    }
    public void CursorMoveUp()
    {
        if ((player.transform.position.y - transform.position.y) != -range)
        {
            mov.MoveUp();
        }
    }
    public void CursorMoveDown()
    {
        if ((player.transform.position.y - transform.position.y) != range)
        {
            mov.MoveDown();
        }
    }
    public void CursorMoveLeft()
    {
        if ((player.transform.position.x - transform.position.x) != range)
        {
            mov.MoveLeft();
        }
    }
    public void CursorMoveRight()
    {
        if ((player.transform.position.x - transform.position.x) != -range)
        {
            mov.MoveRight();
        }
    }
    //private void Update()
    //{
    //    Debug.Log($"Player {player.transform.position}, Cursor {transform.position}, Distance y{player.transform.position.y - transform.position.y} x{player.transform.position.x - transform.position.x}");
    //}
    public int CursorInteract()
    {
        Collider2D col = Physics2D.OverlapBox(transform.position, new Vector2(0.5f,0.5f), 0, mask);
        if (col.transform.CompareTag("Wreck") && col.transform.GetComponent<ResourceSource>().active)
        {
            int ammo = col.transform.GetComponent<ResourceSource>().GetResources();
            Debug.Log($"Got {ammo} ammo from wreck");
            return ammo;
        }
        else
        {
            Debug.Log("Found Nothing" + col.transform.tag);
            return 0;
        }
    }
    public int CursorAttack(int ammo)
    {
        if (ammo != 0)
        {
            Collider2D col = Physics2D.OverlapBox(transform.position, new Vector2(0.5f, 0.5f), 0, mask);
            if (col.transform.CompareTag("Enemy"))
            {
                Destroy(col.transform.gameObject);
                Debug.Log("Hit");
            }
            else
            {
                Debug.Log("NoHit");
            }
            return ammo - 1;
        }
        return ammo;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
