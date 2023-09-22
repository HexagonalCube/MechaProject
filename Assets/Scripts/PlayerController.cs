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
    [SerializeField] TurnHandler turnHandler;
    
    void Start()
    {
        mov = GetComponent<GridMovementScript>();
        fov = GetComponent<PlayerFov>();
        turnHandler.TurnEnd();
    }
    void Update()
    {
        //Check Movement inputs
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("ControllerInput.D");
            mov.MoveRight();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("ControllerInput.A");
            mov.MoveLeft();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Debug.Log("ControllerInput.S");
            mov.MoveDown();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("ControllerInput.W");
            mov.MoveUp();
            turnHandler.TurnEnd();
        }

        //Check Vision Inputs
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("ControllerInput.UP");
            fov.TurnUp();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("ControllerInput.DOWN");
            fov.TurnDown();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("ControllerInput.LEFT");
            fov.TurnLeft();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("ControllerInput.RIGHT");
            fov.TurnRight();
            turnHandler.TurnEnd();
        }

    }
}
