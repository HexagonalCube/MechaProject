using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiComponent : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    [SerializeField] float searchSize;
    [SerializeField] float searchStalk;
    [SerializeField] int steps = 0;
    [SerializeField] int stalkPeriod;
    [SerializeField] GameObject player;
    [SerializeField] bool debugMessage;
    enum Modes
    {
        RNG, Simple, Fast, Stalk, Patrol, Target, Debug
    }
    [SerializeField] Modes modeSelected;

    void Start()
    {
        mov = GetComponent<GridMovementScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnDrawGizmos()
    {
        switch (modeSelected)
        {
            case Modes.Target:
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, transform.position + Vector3.left*3);
                break;
            case Modes.Simple:
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                break;
            case Modes.Fast:
                break;
            case Modes.Stalk:
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, searchStalk);
                break;
            case Modes.Patrol:
                break;
            case Modes.RNG | Modes.Debug:
                Gizmos.color = Color.black;
                Gizmos.DrawIcon(transform.position, "QuestionMarkIcon.png", true);
                break;
        }
    }
    public void TryMove()
    {
        switch (modeSelected)
        {
            case Modes.Target:
                MoveTarget();
                break;
            case Modes.Simple:
                MoveSimple();
                break;
            case Modes.Fast:
                break;
            case Modes.Stalk:
                MoveStalk();
                break;
            case Modes.Patrol:
                break;
            case Modes.RNG:
                MoveRNG();
                break;
            case Modes.Debug:
                Debug.Log(Vector2.Distance(player.transform.position, transform.position));
                break;
        }

    }
    void MoveRNG()
    {
        int rng = Mathf.FloorToInt(UnityEngine.Random.Range(0, 5));
        switch (rng)
        {
            case 0:
                break;
            case 1:
                mov.MoveUp();
                break;
            case 2:
                mov.MoveDown();
                break;
            case 3:
                mov.MoveLeft();
                break;
            case 4:
                mov.MoveRight();
                break;
            case 5:
                break;
        }
    }
    void MoveTarget()
    {
        switch(steps)
        {
            case <3:
                mov.MoveLeft();
                ++steps;
                break;
            case <6:
                mov.MoveRight();
                ++steps;
                break;
            case 6:
                steps = 0;
                MoveTarget();
                break;

        }
    }
    void MoveSimple()
    {
        Vector2 pPos = player.transform.position;
        Vector2 sPos = transform.position;
        if (Vector2.Distance(pPos, sPos) < searchSize)
        {
            if (mov.CheckUp() && pPos.y>sPos.y)
            {
                mov.MoveUp();
            }
            if (mov.CheckDown() && pPos.y<sPos.y)
            {
                mov.MoveDown();
            }
            if (mov.CheckLeft() && pPos.x<sPos.x)
            {
                mov.MoveLeft();
            }
            if (mov.CheckRight() && pPos.x>sPos.x)
            {
                mov.MoveRight();
            }
        }
        else
        {
            MoveRNG();
        }
    }
    void MoveStalk()
    {
        if (debugMessage) { Debug.Log($"MovingStalk"); }
        Vector2 pPos = player.transform.position;
        Vector2 sPos = transform.position;
        float distance = Vector2.Distance(pPos, sPos);
        if (distance < searchSize && distance < searchStalk && steps < stalkPeriod)
        {
            if (debugMessage) { Debug.Log("MovingAway"); }
            if (mov.CheckDown() && pPos.y > sPos.y)
            {
                steps++;
                mov.MoveDown();
            }
            if (mov.CheckUp() && pPos.y < sPos.y)
            {
                mov.MoveUp();
                steps++;
            }
            if (mov.CheckRight() && pPos.x < sPos.x)
            {
                mov.MoveRight();
                steps++;
            }
            if (mov.CheckLeft() && pPos.x > sPos.x)
            {
                mov.MoveLeft();
                steps++;
            }
        }
        if (distance < searchSize && distance > searchStalk && steps < stalkPeriod)
        {
            if (debugMessage) { Debug.Log("MovingCloser"); }
            if (mov.CheckUp() && pPos.y > sPos.y)
            {
                steps++;
                mov.MoveUp();
            }
            if (mov.CheckDown() && pPos.y < sPos.y)
            {
                mov.MoveDown();
                steps++;
            }
            if (mov.CheckLeft() && pPos.x < sPos.x)
            {
                mov.MoveLeft();
                steps++;
            }
            if (mov.CheckRight() && pPos.x > sPos.x)
            {
                mov.MoveRight();
                steps++;
            }
        }
        if (distance < searchSize && steps >= stalkPeriod)
        {
            if (debugMessage) { Debug.Log("MovingToAttack"); }
            if (mov.CheckUp() && pPos.y > sPos.y)
            {
                mov.MoveUp();
            }
            if (mov.CheckDown() && pPos.y < sPos.y)
            {
                mov.MoveDown();
            }
            if (mov.CheckLeft() && pPos.x < sPos.x)
            {
                mov.MoveLeft();
            }
            if (mov.CheckRight() && pPos.x > sPos.x)
            {
                mov.MoveRight();
            }
        }
    }
}
