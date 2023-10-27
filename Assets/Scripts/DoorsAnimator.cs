using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        animator = GetComponent<Animator>();
        animator.Play("DoorCloseIdle");
        OpenDoorsTimed();
    }

    IEnumerator OpenDoorsTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        animator.Play("DoorOpen");
    }
    IEnumerator CloseDoorsTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        animator.Play("DoorClose");
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
    }
    public void OpenDoors()
    {
        animator.Play("DoorOpen");
    }
}
