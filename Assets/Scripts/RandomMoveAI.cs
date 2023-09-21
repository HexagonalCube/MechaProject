using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// Chooses a random direction to move, after recieving signal.
/// </summary>
public class RandomMoveAI : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    void Start()
    {
        mov = GetComponent<GridMovementScript>();
    }
    public void MoveRNG()
    {
        int rng = Mathf.FloorToInt(UnityEngine.Random.Range(0,5));
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
}
