using System;
using UnityEngine;
/// <summary>
/// Sfx base controller, Store your sfx files here, and call it when you need them
/// </summary>
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

    void Start() //Sets default variable values
    {
        speaker.pitch = 1f;
        speaker = GetComponent<AudioSource>();
    }
    public void Alarm() //Plays the alarm sfx (BEHBEHBEH!)
    {
        speaker.PlayOneShot(sfxAlarm);
    }
    public void ButtonGeneric() //Plays the button sfx (Tchuk!)
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxButton);
    }
    public void ButtonSend() //Plays the SendButton sfx (Crrrrrr,Tack!)
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxSendButton);
    }
    public void ButtonClick() //Plays the Click sfx (Click!)
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxClick);
    }
    public void Dial() //Plays the DialChange sfx (Tick!)
    {
        RandomizePitch();
        speaker.PlayOneShot(sfxDial);
    }
    public void ToggleOn() //Plays the ToggleToOn sfx (Catink!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxToggleOn);
    }
    public void ToggleOff() //Plays the ToggleToOff sfx (Cathunk!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxToggleOff);
    }
    public void Notification() //Plays the Notification sfx (DUDUDU!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxNotification);
    }
    public void Denied() //Plays the Denied sfx (EH EH!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxDenied);
    }
    public void EnemyHit() //Plays the ShotHit sfx (Pew,Boom!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxEnemyHit);
    }
    public void ShotMissed() //Plays the ShotMiss sfx (Pew!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxShotMiss);
    }
    public void ObjectiveFound() //Plays the Objective sfx (ahh,AHH!)
    {
        speaker.pitch = 1f;
        speaker.PlayOneShot(sfxObjective);
    }
    public void DoorOpen() //Plays the DoorOpen sfx (Pfff,Tshii!)
    {
        speaker.PlayOneShot(sfxDoorOpen);
    }
    public void DoorClose() //Plays the DoorClose sfx (Tshii,Pf,BLAM!)
    {
        speaker.PlayOneShot(sfxDoorClose);
    }
    void RandomizePitch() //Randomizes sfx pitch to curb monotony!
    {
        speaker.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
    }
}
