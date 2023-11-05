using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SfxController sfx;
    
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        animator = GetComponent<Animator>();
        animator.Play("DoorCloseIdle");
        OpenDoorsTimed();
        sfx = GetComponent<SfxController>();
    }

    IEnumerator OpenDoorsTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        animator.Play("DoorOpen");
        sfx.DoorOpen();
    }
    IEnumerator CloseDoorsTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        animator.Play("DoorClose");
        sfx.DoorClose();
    }
    public void OpenDoorsTimed()
    {
        StartCoroutine(OpenDoorsTimer());
    }
    public void CloseDoorsTimed()
    {
        StartCoroutine(CloseDoorsTimer());
    }
    public void CloseDoors()
    {
        animator.Play("DoorClose");
        sfx.DoorClose();
    }
    public void OpenDoors()
    {
        animator.Play("DoorOpen");
        sfx.DoorOpen();
    }
}
