using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Gets relevant ui interactions and applies effects and functions
/// </summary>

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] GameObject ui_Point_Dial;
    [SerializeField] GameObject ui_Point_Left;
    [SerializeField] GameObject ui_Point_Right;
    [SerializeField] GameObject ui_Point_Up;
    [SerializeField] GameObject ui_Point_Down;
    [SerializeField] UiAnimationScript animScript;
    [SerializeField] PlayerController player;
    [SerializeField] CursorScript cursor;
    [SerializeField] int dirLook;
    [SerializeField] bool gunUse = false;
    [SerializeField] bool movCur = false;
    [SerializeField] bool debugMessage = false;
    private int ammo = 0;
    private void Start()
    {
        ammo = player.startAmmo;
        UpdateAmmo(ammo);
    }
    public void ChangeDial() //Changing dial animation based on cursor position
    {
        //Calculating angle of pointer to dial
        //First get screen points
        Vector2 compPos = ui_Point_Dial.transform.position;
        Vector2 mousePos = Input.mousePosition;
        //Subtracting these points gets the diference or heading
        Vector2 heading = compPos - mousePos;
        //Get distance from 0
        float distance = heading.magnitude;
        //Divide the heading by the distance to get normalized output of 0 to 1
        Vector2 direction = heading / distance;
        //SignedAngle gives the angle in degrees from our starting position in 180 to -180
        float angle = Vector2.SignedAngle(Vector2.down, direction);
        //Check if angle is within margins
        if (Mathf.Abs(angle) < 45)
        {
            if (debugMessage) { Debug.Log("UP"); }
            animScript.DialAnim(0);
            dirLook = 0;
        }
        else if (Mathf.Abs(angle) > 128)
        {
            if (debugMessage) { Debug.Log("DOWN"); }
            animScript.DialAnim(2);
            dirLook = 2;
        }
        else if (angle > 45 && angle < 128)
        {
            if (debugMessage) { Debug.Log("LEFT"); }
            animScript.DialAnim(3);
            dirLook = 1;
        }
        else if (angle < -45 && angle > -128)
        {
            if (debugMessage) { Debug.Log("RIGHT"); }
            animScript.DialAnim(1);
            dirLook = 3;
        }
    }
    public void DirectionPress() //Single function to streamline direction input
    {
        //Using one ui element for 4 interactions by distance
        //Get screen points
        Vector2 lPos = ui_Point_Left.transform.position;
        Vector2 rPos = ui_Point_Right.transform.position;
        Vector2 uPos = ui_Point_Up.transform.position;
        Vector2 dPos = ui_Point_Down.transform.position;
        Vector2 mousePos = Input.mousePosition;
        //Get distance of cursor to screen points
        float lDist = (lPos - mousePos).magnitude;
        float rDist = (rPos - mousePos).magnitude;
        float uDist = (uPos - mousePos).magnitude;
        float dDist = (dPos - mousePos).magnitude;
        if (debugMessage) { Debug.Log($"Up {uDist}| Down{ dDist}| Left {lDist}| Right {rDist}"); }
        //Check if distance is inside interactable area
        if (uDist < 45 && player.toggleInput) //UP
        {
            animScript.DirAnim(0);
            if (movCur)
            {
                cursor.CursorMoveUp();
            }
            else
            {
                player.MoveInput(0);
            }
        }
        if (dDist < 45 && player.toggleInput) //DOWN
        {
            animScript.DirAnim(2);
            if (movCur)
            {
                cursor.CursorMoveDown();
            }
            else
            {
                player.MoveInput(2);
            }
        }
        if (lDist < 45 && player.toggleInput) //LEFT
        {
            animScript.DirAnim(3);
            if (movCur)
            {
                cursor.CursorMoveLeft();
            }
            else
            {
                player.MoveInput(1);
            }
        }
        if (rDist < 45 && player.toggleInput) //Right
        {
            animScript.DirAnim(1);
            if (movCur)
            {
                cursor.CursorMoveRight();
            }
            else
            {
                player.MoveInput(3);
            }
        }
    }
    public void ButtonPress(int type) //Single function to streamline buttons input, button type set in editor;
    {
        animScript.ButtonAnim(type);
        if (movCur)
        {
            if (gunUse)
            {
                ammo = cursor.CursorAttack(ammo);
                UpdateAmmo(ammo);
                if (debugMessage) { Debug.Log("NewAmmo " + ammo); }
            }
            else
            {
                ammo += cursor.CursorInteract();
                UpdateAmmo(ammo);
                if (debugMessage) { Debug.Log("NewAmmo " + ammo); }
            }
            player.NewTurn();
        }
        if (type == 1)
        {
            player.ViewInput(dirLook);
        }
    }
    public void ToggleGunUse() //Toggles switch values and animations
    {
        if (gunUse)
        {
            animScript.ToggleGunUseAnim(gunUse);
            gunUse = false;
            if (debugMessage) { Debug.Log("Toggle GU " + gunUse); }
        }
        else
        {
            animScript.ToggleGunUseAnim(gunUse);
            gunUse = true;
            if (debugMessage) { Debug.Log("Toggle GU " + gunUse); }
        }
    }
    public void ToggleMovCur() //Toggles switch values and animations
    {
        if (movCur)
        {
            animScript.ToggleMovCurAnim(movCur);
            movCur = false;
            if (debugMessage) { Debug.Log("Toggle MC " + movCur); }
            cursor.CursorChangeActive(movCur);
        }
        else 
        {
            animScript.ToggleMovCurAnim(movCur);
            movCur = true;
            if (debugMessage) { Debug.Log("Toggle MC " + movCur); }
            cursor.CursorChangeActive(movCur);
        }
    }
    public void UpdateAmmo(int count) //Updates LCD with ammo count
    {
        animScript.UpdateLCD(count);
    }
    private void Update()
    {
        if (debugMessage) //Debugging animations and values
        {
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                ammo++;
                Debug.Log($"+ammo, now {ammo}");
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                ammo--;
                Debug.Log($"-ammo, now {ammo}");
            }
            UpdateAmmo(ammo);
        }
    }
}
