using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    [SerializeField] AudioSource speaker;
    [SerializeField] AudioClip sfxAlarm;
    [SerializeField] AudioClip sfx2;
    [SerializeField] AudioClip sfx3;
    [SerializeField] AudioClip sfx4;
    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }
    public void Alarm()
    {
        speaker.PlayOneShot(sfxAlarm);
    }
}
