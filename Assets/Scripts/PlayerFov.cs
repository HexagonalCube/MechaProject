using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rotates the FOV game object. Needs controller to call commands.
/// </summary>
public class PlayerFov : MonoBehaviour
{
    [SerializeField] GameObject fov;
    [SerializeField] GameObject sprite;
    public void TurnLeft() //Turns the FOV & player sprite to the left
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 90);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 90);
        Debug.Log("LookingLEFT");
    }
    public void TurnRight() //Turns the FOV & player sprite to the right
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, -90);
        sprite.transform.rotation = Quaternion.Euler(0, 0, -90);
        Debug.Log("LookingRIGHT");
    }
    public void TurnUp() //Turns the FOV & player sprite up
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 0);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("LookingUP");
    }
    public void TurnDown() //Turns the FOV & player sprite down
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 180);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 180);
        Debug.Log("LookingDOWN");
    }
}
