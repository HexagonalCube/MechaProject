using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SfxController sfx;
    [SerializeField] bool openStart = true; //If opens on start
    
    void Start() //Gets Relevant Variables
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        animator = GetComponent<Animator>();
        animator.Play("DoorCloseIdle");
        if (openStart) { OpenDoorsTimed(); }
        sfx = GetComponent<SfxController>();
    }

    IEnumerator OpenDoorsTimer() //Opens doors when timer ends
    {
        yield return new WaitForSecondsRealtime(1);
        animator.Play("DoorOpen");
        sfx.DoorOpen();
    }
    IEnumerator CloseDoorsTimer() //Close doors when timer ends
    {
        yield return new WaitForSecondsRealtime(1);
        animator.Play("DoorClose");
        sfx.DoorClose();
    }
    public void OpenDoorsTimed() //Used by other scripts to Open Doors
    {
        StartCoroutine(OpenDoorsTimer());
    }
    public void CloseDoorsTimed() //Used by other scripts to Close Doors
    {
        StartCoroutine(CloseDoorsTimer());
    }
    public void CloseDoors() //Imidiate Close Doors
    {
        animator.Play("DoorClose");
        sfx.DoorClose();
    }
    public void OpenDoors() //Imidiate Open Doors
    {
        animator.Play("DoorOpen");
        sfx.DoorOpen();
    }
}
