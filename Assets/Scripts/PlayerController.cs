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
    [SerializeField] bool debugMessage;
    
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
            if (debugMessage) { Debug.Log("ControllerInput.D"); }
            mov.MoveRight();
            turnHandler.TurnEnd();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (debugMessage) { Debug.Log("ControllerInput.A"); }
            mov.MoveLeft();
            turnHandler.TurnEnd();
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            if (debugMessage) { Debug.Log("ControllerInput.S"); }
            mov.MoveDown();
            turnHandler.TurnEnd();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (debugMessage) { Debug.Log("ControllerInput.W"); }
            mov.MoveUp();
            turnHandler.TurnEnd();
        }

        //Check Vision Inputs
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (debugMessage) { Debug.Log("ControllerInput.UP"); }
            fov.TurnUp();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (debugMessage) { Debug.Log("ControllerInput.DOWN"); }
            fov.TurnDown();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (debugMessage) { Debug.Log("ControllerInput.LEFT"); }
            fov.TurnLeft();
            turnHandler.TurnEnd();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (debugMessage) { Debug.Log("ControllerInput.RIGHT"); }
            fov.TurnRight();
            turnHandler.TurnEnd();
        }

    }
}
