using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFov : MonoBehaviour
{
    [SerializeField] GameObject fov;
    public void TurnLeft()
    {
        fov.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
    public void TurnRight()
    {
        fov.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
    public void TurnUp()
    {
        fov.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void TurnDown()
    {
        fov.transform.rotation = Quaternion.Euler(180, 0, 0);
    }
}
