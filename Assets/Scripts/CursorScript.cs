using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer sprite;
    public float range = 5;
    [SerializeField] LayerMask mask;
    [SerializeField] TextUpdater text;
    [SerializeField] SfxController sfx;

    void Start() //Gets component variables
    {
        mov = GetComponent<GridMovementScript>();
        text = FindAnyObjectByType<TextUpdater>().GetComponent<TextUpdater>();
    }
    public void CursorChangeActive(bool active) //Activates cursor on screen
    {
        transform.position = player.transform.transform.position;
        sprite.enabled = active;
    }
    public void CursorMoveUp() //Moves cursor up
    {
        if ((player.transform.position.y - transform.position.y) != -range)
        {
            mov.MoveUp();
        }
    }
    public void CursorMoveDown() //Moves cursor down
    {
        if ((player.transform.position.y - transform.position.y) != range)
        {
            mov.MoveDown();
        }
    }
    public void CursorMoveLeft() //Moves cursor left
    {
        if ((player.transform.position.x - transform.position.x) != range)
        {
            mov.MoveLeft();
        }
    }
    public void CursorMoveRight() //Moves cursor right
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
    public int CursorInteract() //What to do when interaction is called
    {
        Collider2D col = Physics2D.OverlapBox(transform.position, new Vector2(0.5f,0.5f), 0, mask); //gets object selected
        if (col != null) //if selected isnt null
        {
            if (col.transform.CompareTag("Wreck") && col.transform.GetComponent<ResourceSource>().active) //on found resource
            {
                int ammo = col.transform.GetComponent<ResourceSource>().GetResources();
                text.SendTextMessage($"Got <color=\"yellow\">{ammo} ammo <color=\"white\">from wreck.");
                Debug.Log($"Got {ammo} ammo from wreck");
                return ammo;
            }
            else if (/*col.transform.GetComponent<LevelEndScript>() != null*/col.transform.CompareTag("Finish")) //on found objective
            {
                //winImage.sprite = winSprite;
                //winImage.enabled = true;
                text.SendTextMessage($"Found <color=\"yellow\">Objective<color=\"white\">!");
                sfx.ObjectiveFound();
                col.transform.GetComponent<ObjectiveScript>().AddObjective();
                return 0;
            }
            else if (col.transform.CompareTag("Enemy")) //on found enemy
            {
                text.SendTextMessage($"Found <color=\"red\">ENEMY<color=\"white\">!");
                Debug.Log("Found Enemy!" + col.transform.tag);
                return 0;
            }
            else if (col.transform.CompareTag("Rock")) //on found rock
            {
                text.SendTextMessage($"Found <color=\"green\">Rock<color=\"white\">.");
                Debug.Log("Found Rock" + col.transform.tag);
                return 0;
            }
            else //on found nothing else
            {
                text.SendTextMessage($"Found <color=\"purple\">Nothing<color=\"white\">.");
                return 0;
            }
        }
        else //if touched nothing
        {
            if (transform.position == player.transform.position) //is you
            {
                text.SendTextMessage($"That's <color=\"orange\">You<color=\"white\">!");
                Debug.Log("Found Yourself!");
                return 0;
            }
            else //is nothing
            {
                text.SendTextMessage($"Found <color=\"purple\">Nothing<color=\"white\">.");
                return 0;
            }
        }
    }
    public int CursorAttack(int ammo) //Attacks Selected Object
    {
        if (ammo != 0)
        {
            Collider2D col = Physics2D.OverlapBox(transform.position, new Vector2(0.5f, 0.5f), 0, mask);
            if (col == null && !(transform.position == player.transform.position)) //if hit nothing and not hit yourself
            {
                sfx.ShotMissed();
                text.SendTextMessage($"Hit <color=\"purple\">Nothing<color=\"white\">.");
                Debug.Log("NoHit");
                return ammo - 1;
            }
            else if (col != null && col.transform.CompareTag("Enemy")) //if hit enemy
            {
                col.transform.GetComponent<AiComponent>().Death();
                //Destroy(col.transform.gameObject);
                sfx.EnemyHit();
                text.SendTextMessage($"Hit <color=\"red\">ENEMY<color=\"white\">!");
                Debug.Log("Hit");
                return ammo - 1;
            }
            else if (col != null && col.transform.CompareTag("Rock")) //if hit rock
            {
                sfx.ShotMissed();
                text.SendTextMessage($"Hit <color=\"green\">Rock<color=\"white\">.");
                Debug.Log("NoHit");
                return ammo - 1;
            }
            else if (transform.position == player.transform.position)//if tries to shoot yourself
            {
                sfx.Denied();
                text.SendTextMessage($"Can't <color=\"red\">Shoot <color=\"orange\">Yourself<color=\"white\">!");
                Debug.Log("Can't Shoot Yourself");
                return ammo;
            }
            else //if all else fails
            {
                sfx.ShotMissed();
                Debug.Log("EdgeCaseMiss" + col.transform.name);
                return ammo - 1;
            }
        }
        return ammo;
    }
    private void OnDrawGizmos() // drawn cursor
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
