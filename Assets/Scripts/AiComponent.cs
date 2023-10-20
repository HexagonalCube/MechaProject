using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Main AI component to enemies
/// Change modes to display Actions
/// </summary>
public class AiComponent : MonoBehaviour
{
    [SerializeField] GridMovementScript mov; //Grid Movement component.
    [SerializeField] float searchSize; //Size in radius of the area arround enemy to search for player.
    [SerializeField] float searchStalk; //Size in radius of the area arround enemy to keep distance from player.
    [SerializeField] float patrolSize; //Size in radius of the area arround PatrolPoint to keep enemy inside.
    int steps = 0; //Step counter in premade behaviour.
    [SerializeField] int stalkPeriod; //Period to wait before hunting player.
    [SerializeField] GameObject player; //Player to compare against.
    [SerializeField] GameObject PatrolPoint; //Point to base the Patrol Area arround.
    enum Modes
    {
        RNG, Simple, Ambush, Stalk, Patrol, Target, Debug, Disabled
    } //Selectable Behaviour Modes.
    [SerializeField] Modes modeSelected; // Mode selected in Editor.
    [SerializeField] int damage;
    public bool hunting; //If the enemy is hunting player.
    [SerializeField] bool debugMode; //If in debug mode.

    void Start() //Gets relevant component variables.
    {
        mov = GetComponent<GridMovementScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate() //Used only in debug.
    {
        if (debugMode)
        {
            TryMove();
        }
    }
    private void OnDrawGizmos()
    {
        switch (modeSelected)
        {
            case Modes.Target:
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, transform.position + Vector3.left*4);
                break;
            case Modes.Simple:
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                break;
            case Modes.Ambush:
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                break;
            case Modes.Stalk:
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, searchStalk);
                break;
            case Modes.Patrol:
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(PatrolPoint.transform.position, patrolSize);
                break;
            case Modes.RNG | Modes.Debug:
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, searchSize);
                Gizmos.color = Color.black;
                Gizmos.DrawIcon(transform.position, "QuestionMarkIcon.png", true);
                break;
        }
    } //Gizmo AI behaviour reprsentation.

    ////////////////////////////////////////////////////////FUNCTIONS/////////////////////////////////////////////////////////////////////////
    public void TryMove() //Used by controller to give the step instruction at round end.
    {
        switch (modeSelected)
        {
            case Modes.Target:
                MoveTarget();
                break;
            case Modes.Simple:
                MoveSimple();
                break;
            case Modes.Ambush:
                MoveAmbush();
                break;
            case Modes.Stalk:
                MoveStalk();
                break;
            case Modes.Patrol:
                MovePatrol();
                break;
            case Modes.RNG:
                MoveRNG();
                break;
            case Modes.Debug:
                Debug.Log(Vector2.Distance(player.transform.position, transform.position));
                break;
            case Modes.Disabled:
                break;
        }
        if (debugMode) { Debug.Log("AiMove"); }
    }
    void MoveRNG() //Tries to move to a random valid position, no chase function.

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
        Spotting();
    }
    void MoveTarget() //Moves in a left-right pattern within the steps counter, no chase function.

    {
        switch (steps)
        {
            case <4:
                mov.MoveLeft();
                ++steps;
                break;
            case <8:
                mov.MoveRight();
                ++steps;
                break;
            case 8:
                steps = 0;
                MoveTarget();
                break;

        }
        Spotting();
    }
    void MoveSimple() //Uses MoveRNG if no player sighted, chases player position if sighted.
    {
        Vector2 pPos = player.transform.position;
        Vector2 sPos = transform.position;
        if (Vector2.Distance(pPos, sPos) < searchSize)
        {
            if (Vector2.Distance(pPos, sPos) > 1)
            {
                hunting = true;
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
            else
            {
                DamagePlayer();
            }
        }
        else
        {
            hunting= false;
            //GetComponentInParent<TurnHandler>().Spotting(hunting);
            MoveRNG();
        }
    }
    void MoveStalk() //Stays still if no player sighted, stays within searchStalk radius when player sihgted,chases player at end of stalkPeriod.

    {
        if (debugMode) { Debug.Log($"MovingStalk"); }
        Vector2 pPos = player.transform.position;
        Vector2 sPos = transform.position;
        float distance = Vector2.Distance(pPos, sPos);
        if (distance < searchSize && distance < searchStalk && steps < stalkPeriod)
        {
            hunting = true;
            if (debugMode) { Debug.Log("MovingAway"); }
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
            hunting = true;
            if (debugMode) { Debug.Log("MovingCloser"); }
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
            hunting = true;
            if (debugMode) { Debug.Log("MovingToAttack"); }
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
        //GetComponentInParent<TurnHandler>().Spotting(hunting);
    }
    void MovePatrol() //Uses MoveSimple if inside search area, moves to center of search area when outside.

    {
        Vector2 pPos = PatrolPoint.transform.position;
        Vector2 sPos = transform.position;
        if (Vector2.Distance(pPos, sPos) > patrolSize)
        {
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

            if (!mov.CheckUp() && pPos.y > sPos.y) { steps++; TryCenter(pPos); }
            if (!mov.CheckDown() && pPos.y < sPos.y) { steps++; TryCenter(pPos); }
            if (!mov.CheckLeft() && pPos.x < sPos.x) { steps++; TryCenter(pPos); }
            if (!mov.CheckRight() && pPos.x > sPos.x) { steps++; TryCenter(pPos); }
        }
        else
        {
            MoveSimple();
        }
    }
    void MoveAmbush() //Stays still if no player sighted, chases player if sighted.

    {
        Vector2 pPos = player.transform.position;
        Vector2 sPos = transform.position;
        if (Vector2.Distance(pPos, sPos) < searchSize)
        {
            hunting = true;
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
        //GetComponentInParent<TurnHandler>().Spotting(hunting);
    }
    void TryCenter(Vector2 pPos) //Centers the enemy in area point.

    {
        if (steps >= 10)
        {
            if (debugMode) { Debug.Log("Centering"); }
            transform.position = pPos;
            steps = 0;
        }
    }
    void DamagePlayer() //Deals damage to player
    {
        player.GetComponent<PlayerController>().Damage();
    }
    void Spotting()
    {
        Vector2 pPos = player.transform.position;
        Vector2 sPos = transform.position;
        if (Vector2.Distance(pPos, sPos) < searchSize)
        {
            hunting = true;
        }
        else
        {
            hunting = false;
        }
        //GetComponentInParent<TurnHandler>().Spotting(hunting);
    } //Sets hunting bool to true if player sighted
    public void Death()
    {
        hunting = false;
        if (GetComponentInParent<TurnHandler>().UpdateList())
        {
            DisableAll();
        }
    }
    void DisableAll()
    {
        modeSelected = Modes.Disabled;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<AiComponent>().enabled = false;
        gameObject.GetComponent<GridMovementScript>().enabled = false;
        gameObject.GetComponent<DistanceRenderer>().enabled = false;
    }
}