using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimationScript : MonoBehaviour
{
    [SerializeField] Animator ui_Dial;
    [SerializeField] Animator ui_Dir;
    [SerializeField] Animator ui_Button;
    [SerializeField] Animator ui_Toggle_GunUse;
    [SerializeField] Animator ui_Toggle_MovCur;
    [SerializeField] Animator ui_Send;
    [SerializeField] Animator ui_LCD;
    /// <summary>
    /// Changes Dial direction using int
    /// from 0-3, clockwise, 0 is up;
    /// </summary>
    /// <param name="dir"> int in 0-3.</param>
    public void DialAnim(int dir)
    {
        switch (dir)
        {
            case 0:
                ui_Dial.Play("DialUp");
                break;
            case 1:
                ui_Dial.Play("DialRight");
                break;
            case 2:
                ui_Dial.Play("DialDown");
                break;
            case 3:
                ui_Dial.Play("DialLeft");
                break;
        }
    }
    /// <summary>
    /// Animates the direction cluster using int
    /// 0-3, clockwise, 0 is up
    /// </summary>
    /// <param name="dir">int 0-3.</param>
    public void DirAnim(int dir)
    {
        switch (dir)
        {
            case 0:
                ui_Dir.Play("DirUp");
                break;
            case 1:
                ui_Dir.Play("DirRight");
                break;
            case 2:
                ui_Dir.Play("DirDown");
                break;
            case 3:
                ui_Dir.Play("DirLeft");
                break;
        }
    }
    public void ButtonAnim(int type)
    {
        if (type == 0)
        {
            ui_Button.Play("ButtonPress");
        }
        else if (type == 1)
        {
            ui_Send.Play("SendPress");
        }
    }
    public void ToggleGunUseAnim(bool state)
    {
        if (state)
        {
            ui_Toggle_GunUse.Play("Use");
        }
        else
        {
            ui_Toggle_GunUse.Play("Gun");
        }
    }
    public void ToggleMovCurAnim(bool state)
    {
        if(state)
        {
            ui_Toggle_MovCur.Play("Mov");
        }
        else
        {
            ui_Toggle_MovCur.Play("Cur");
        }
    }
    public void UpdateLCD(int count)
    {
        if(count<11)
        {
            ui_LCD.Play("LCD"+count.ToString());
        }
        else
        {
            ui_LCD.Play("LCD10");
        }
    }
}
