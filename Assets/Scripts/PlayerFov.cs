using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rotates the FOV game object. Needs controller to call commands.
/// </summary>
public class PlayerFov : MonoBehaviour
{
    [SerializeField] GameObject fov;
    public void TurnLeft()
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 90);
        Debug.Log("LookingLEFT");
    }
    public void TurnRight()
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, -90);
        Debug.Log("LookingRIGHT");
    }
    public void TurnUp()
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("LookingUP");
    }
    public void TurnDown()
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 180);
        Debug.Log("LookingDOWN");
    }
}
