using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Keyboard Interface, so that keys can be changed and experimented
/// </summary>
public class KeyBoardScript : MonoBehaviour
{
    [SerializeField] KeyCode dirUp = KeyCode.UpArrow;
    [SerializeField] KeyCode dirDown = KeyCode.DownArrow;
    [SerializeField] KeyCode dirLeft = KeyCode.LeftArrow;
    [SerializeField] KeyCode dirRight = KeyCode.RightArrow;
    [SerializeField] KeyCode lookUp = KeyCode.W;
    [SerializeField] KeyCode lookDown = KeyCode.S;
    [SerializeField] KeyCode lookLeft = KeyCode.A;
    [SerializeField] KeyCode lookRight = KeyCode.D;
    [SerializeField] KeyCode send = KeyCode.F;
    [SerializeField] KeyCode interact = KeyCode.Space;
    [SerializeField] KeyCode toggle1 = KeyCode.Q;
    [SerializeField] KeyCode toggle2 = KeyCode.E;
    [SerializeField] InteractionHandler script;
    private void Start() //Get script to send commands to
    {
        script = GetComponent<InteractionHandler>();
    }

    void Update() //Get Inputs
    {
        if (Input.anyKeyDown)
        {
            script.HighlightReset();
        }
        if (Input.GetKeyDown(dirUp))
        {
            script.DirectionPressKeyboard(0);
        }
        if (Input.GetKeyDown(dirDown))
        {
            script.DirectionPressKeyboard(2);
        }
        if (Input.GetKeyDown(dirLeft))
        {
            script.DirectionPressKeyboard(3);
        }
        if (Input.GetKeyDown(dirRight))
        {
            script.DirectionPressKeyboard(1);
        }
        if (Input.GetKeyDown(lookUp))
        {
            script.ChangeDialKeyboard(0);
        }
        if (Input.GetKeyDown(lookDown))
        {
            script.ChangeDialKeyboard(180);
        }
        if (Input.GetKeyDown(lookLeft))
        {
            script.ChangeDialKeyboard(90);
        }
        if (Input.GetKeyDown(lookRight))
        {
            script.ChangeDialKeyboard(-90);
        }
        if (Input.GetKeyDown(send)) { script.ButtonPress(1); }
        if (Input.GetKeyDown(interact)) { script.ButtonPress(0); }
        if (Input.GetKeyDown(toggle1)) { script.ToggleGunUse(); }
        if (Input.GetKeyDown(toggle2)) { script.ToggleMovCur(); }
    }
}
