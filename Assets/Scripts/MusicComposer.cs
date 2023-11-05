using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Jumbles music from midClips, adds the startClip and endClip to the jumbled soundtrack.
/// </summary>

public class MusicComposer : MonoBehaviour
{
    [SerializeField] AudioClip musicStart;
    [SerializeField] AudioClip[] musicFills;
    [SerializeField] AudioClip musicEnd;
    public AudioSource audioSpeaker;
    [SerializeField] int nextClip = 99;
    [SerializeField] int playingClip = 100;
    public bool scheduleEnd = false;
    public bool playingEnd = false;
    [SerializeField] int[] previousClips;
    [SerializeField] bool debugMessage;

    private void Start()
    {
        //Gets the necessary components
        audioSpeaker = GetComponent<AudioSource>();
        //Sets important values for sequencing to work
        previousClips =  new int[musicFills.Length];
        previousClips[^ 1] = nextClip;
    }
    //StartClip plays the nextClip index of musicFills, except when starting from nothing,
    //value 99 & 100 is reserved for indexing and queueing tricks.
    public void StartClip()
    {
        switch (nextClip)
        {
            case 99:
                if (debugMessage) { Debug.Log($"PlayingStartClip"); }
                audioSpeaker.PlayOneShot(musicStart);
                playingClip = nextClip;
                nextClip = 0;
                break;
            case < 99:
                if (debugMessage) { Debug.Log($"Playing{musicFills[nextClip]}"); }
                audioSpeaker.PlayOneShot(musicFills[nextClip]);
                playingClip = nextClip;
                break;
        }
        previousClips = ShiftArray(previousClips);
    }
    //On fixed update, we run checks
    private void FixedUpdate()
    {
        //Here it checks if the next clip to be played is already playing or was just played, to avoid monotony
        if (nextClip == playingClip | previousClips[^ 2] == nextClip && !scheduleEnd)
        {
            previousClips[^ 1] = nextClip;
            nextClip = UnityEngine.Random.Range(0,musicFills.Length);
            if (debugMessage) { Debug.Log($"FoundNextClip{nextClip}"); }
        }
        //If it finds a clip fit to be played, it waits for the previous one to end so that it can start its next one
        else if (!scheduleEnd && !audioSpeaker.isPlaying)
        {
            StartClip();
            playingEnd = false;
            if (debugMessage) { Debug.Log("PlayingNextClip"); }
        }
        //If an external actor wants to end this loop, it plays the closing clip then sets up the script to re-run
        else if (scheduleEnd && !audioSpeaker.isPlaying)
        {
            audioSpeaker.PlayOneShot(musicEnd);
            nextClip = 99;
            playingEnd = true;
            if (debugMessage) { Debug.Log("PlayingEndClip"); }
        }

    }
    //Here the ShiftArray Shifts the previousClips playlist so that we can prevent repetition in the clips
    private int[] ShiftArray(int[]oldArray)
    {
        int[] newArray = new int[oldArray.Length];
        Array.Copy(oldArray, 1, newArray, 0, oldArray.Length - 1);
        return newArray;
    }

}
