using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// Chooses a random direction to move, after recieving signal. UNUSED, PRE - 0.0.8 Testing code.
/// </summary>
public class RandomMoveAI : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    void Start() //Gets Component
    {
        mov = GetComponent<GridMovementScript>();
    }
    public void MoveRNG() //Gets random direction and tries to move in that direction, no brain no nothing, purely to test other entyties
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
