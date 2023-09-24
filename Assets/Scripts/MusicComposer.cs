using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
/// <summary>
/// Jumbles music from midClips, adds the startClip and endClip to the jumbled soundtrack.
/// </summary>

public class MusicComposer : MonoBehaviour
{
    [SerializeField] AudioClip musicStart;
    [SerializeField] AudioClip[] musicFills;
    [SerializeField] AudioClip musicEnd;
    [SerializeField] AudioSource audioSpeaker;
    [SerializeField] int nextClip = 99;
    [SerializeField] int playingClip = 99;
    public bool scheduleEnd = false;

    private void Start()
    {
        audioSpeaker = GetComponent<AudioSource>();
        nextClip = UnityEngine.Random.Range(0, 3); 
    }
    public void StartClip()
    {
        switch (nextClip)
        {
            case 99:
                Debug.Log($"Playing START");
                audioSpeaker.PlayOneShot(musicStart);
                playingClip = nextClip;
                break;
            case < 99:
                Debug.Log($"Playing{musicFills[nextClip]}");
                audioSpeaker.PlayOneShot(musicFills[nextClip]);
                playingClip = nextClip;
                break;
        }
    }
    private void FixedUpdate()
    {
        if (nextClip == playingClip && !scheduleEnd)
        {
            nextClip = UnityEngine.Random.Range(0,musicFills.Length);
            Debug.Log("FoundNextClip");
        }
        else if (!scheduleEnd && !audioSpeaker.isPlaying)
        {
            StartClip();
            Debug.Log("PlayingNextClip");
        }
        else if (scheduleEnd && !audioSpeaker.isPlaying)
        {
            audioSpeaker.PlayOneShot(musicEnd);
            nextClip = 99;
            Debug.Log("PlayingEndClip");
        }

    }

}
