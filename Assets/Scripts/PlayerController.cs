using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// used for tests, movement will be controlled by ui
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    [SerializeField] PlayerFov fov;
    [SerializeField] TurnHandler turnEnd;
    
    void Start()
    {
        mov = GetComponent<GridMovementScript>();
        fov = GetComponent<PlayerFov>();
    }
    void Update()
    {
        //Check Movement inputs
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("ControllerInput.D");
            mov.MoveRight();
            turnEnd.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("ControllerInput.A");
            mov.MoveLeft();
            turnEnd.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Debug.Log("ControllerInput.S");
            mov.MoveDown();
            turnEnd.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("ControllerInput.W");
            mov.MoveUp();
            turnEnd.TurnEnd();
        }

        //Check Vision Inputs
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("ControllerInput.UP");
            fov.TurnUp();
            turnEnd.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("ControllerInput.DOWN");
            fov.TurnDown();
            turnEnd.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("ControllerInput.LEFT");
            fov.TurnLeft();
            turnEnd.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("ControllerInput.RIGHT");
            fov.TurnRight();
            turnEnd.TurnEnd();
        }

    }
}
