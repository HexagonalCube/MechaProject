using System;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    [SerializeField] AudioSource speaker;
    [SerializeField] AudioClip sfxAlarm;
    [SerializeField] AudioClip sfxButton;
    [SerializeField] AudioClip sfxSendButton;
    [SerializeField] AudioClip sfxDial;
    [SerializeField] AudioClip sfxClick;
    [SerializeField] AudioClip sfxToggleOn;
    [SerializeField] AudioClip sfxToggleOff;
    [SerializeField] AudioClip sfxNotification;
    [SerializeField] AudioClip sfxDoorOpen;
    [SerializeField] AudioClip sfxDoorClose;
    [SerializeField] AudioClip sfxEnemyHit;
    [SerializeField] AudioClip sfxShotMiss;
    [SerializeField] AudioClip sfxDenied;
    [SerializeField] AudioClip sfxObjective;
    // Start is called before the first frame update
    void Start()
    {
        speaker.pitch = 1f;
        speaker = GetComponent<AudioSource>();
    }
    public void Alarm()
    {
        speaker.PlayOneShot(sfxAlarm);
    }
    public void ButtonGeneric()
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxButton);
    }
    public void ButtonSend()
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxSendButton);
    }
    public void ButtonClick()
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxClick);
    }
    public void Dial()
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxDial);
    }
    public void ToggleOn()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxToggleOn);
    }
    public void ToggleOff()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxToggleOff);
    }
    public void Notification()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxNotification);
    }
    public void Denied()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxDenied);
    }
    public void EnemyHit()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxEnemyHit);
    }
    public void ShotMissed()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxShotMiss);
    }
    public void ObjectiveFound()
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxObjective);
    }
    public void DoorOpen()
    {
        speaker.PlayOneShot(sfxDoorOpen);
    }
    public void DoorClose()
    {
        speaker.PlayOneShot(sfxDoorClose);
    }
    void RandomizePitch()
    {
        speaker.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
    }
}
