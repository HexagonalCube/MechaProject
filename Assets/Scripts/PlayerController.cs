using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GridMovementScript mov;
    [SerializeField] PlayerFov fov;
    [SerializeField] TurnHandler turnHandler;
    [SerializeField] SfxController sfx;
    [SerializeField] Animator border;
    [SerializeField] DamageModel dmgModel;
    [SerializeField] float inputWaitTime;
    public int startAmmo;
    [SerializeField] bool debugMessage;
    public bool toggleInput = true;
    private IEnumerator coroutine;
    bool stopSFX;
    
    void Start()
    {
        mov = GetComponent<GridMovementScript>();
        fov = GetComponent<PlayerFov>();
        turnHandler.TurnEnd();
        coroutine = ResetTime(inputWaitTime);
        StartCoroutine(coroutine);
    }
    void Update()
    {
        //Check if Spotted
        if (turnHandler.spotted && !stopSFX)
        {
            border.Play("Alert");
            sfx.Alarm();
            stopSFX = true;
        }else if (!turnHandler.spotted && stopSFX)
        {
            border.Play("Idle");
            stopSFX= false;
        }
    }
    public void ViewInput(int dir)
    {
        if (toggleInput)
        {
            switch (dir)
            {
                case 0: //UP
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.ViewUP"); }
                    fov.TurnUp();
                    NewTurn();
                    break;
                case 1: //LEFT
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.ViewLEFT"); }
                    fov.TurnLeft();
                    NewTurn();
                    break;
                case 2: //DOWN
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.ViewDOWN"); }
                    fov.TurnDown();
                    NewTurn();
                    break;
                case 3: //RIGHT
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.ViewRIGHT"); }
                    fov.TurnRight();
                    NewTurn();
                    break;
            }
        }
    }
    public void MoveInput(int dir)
    {
        if (toggleInput)
        {
            switch (dir)
            {
                case 0: //UP
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovUP"); }
                    mov.MoveUp();
                    NewTurn();
                    break;
                case 1: //LEFT
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovLEFT"); }
                    mov.MoveLeft();
                    NewTurn();
                    break;
                case 2: //DOWN
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovDOWN"); }
                    mov.MoveDown();
                    NewTurn();
                    break;
                case 3://RIGHT
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovRIGHT"); }
                    mov.MoveRight();
                    NewTurn();
                    break;
            }
        }
    }
    public void NewTurn()
    {
        turnHandler.TurnEnd();
    }
    public void Damage()
    {
        dmgModel.DamageRNG();
    }
    private IEnumerator ResetTime(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            toggleInput = true;
        }
    }
}
