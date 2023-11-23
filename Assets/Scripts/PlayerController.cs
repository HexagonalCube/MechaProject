using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player Commands In-Between & Sfx
/// </summary>
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
    
    void Start() //sets default variables
    {
        mov = GetComponent<GridMovementScript>();
        fov = GetComponent<PlayerFov>();
        turnHandler.TurnEnd();
        coroutine = ResetTime(inputWaitTime);
        StartCoroutine(coroutine);
    }
    void Update()//Check if spotted & play alarm
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
    public void ViewInput(int dir) //Changes view direction 0-3
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
    public void MoveInput(int dir) //Moves to direction if able 0-3
    {
        if (toggleInput)
        {
            switch (dir)
            {
                case 0: //UP
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovUP"); }
                    if (!mov.MoveUp()) { sfx.Denied(); }
                    NewTurn();
                    break;
                case 1: //LEFT
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovLEFT"); }
                    if (!mov.MoveLeft()) { sfx.Denied(); }
                    NewTurn();
                    break;
                case 2: //DOWN
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovDOWN"); }
                    if (!mov.MoveDown()) { sfx.Denied(); }
                    NewTurn();
                    break;
                case 3://RIGHT
                    toggleInput = false;
                    if (debugMessage) { Debug.Log("Controller.MovRIGHT"); }
                    if (!mov.MoveRight()) { sfx.Denied(); }
                    NewTurn();
                    break;
            }
        }
    }
    public void NewTurn() //Signal turn End
    {
        turnHandler.TurnEnd();
    }
    public void Damage() //Signal player damage
    {
        dmgModel.DamageRNG();
    }
    private IEnumerator ResetTime(float waitTime) //wait time between actions (unused, set to 0)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            toggleInput = true;
        }
    }
}
