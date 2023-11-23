using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// Applies music fade effects when transitioning to a different scene
/// </summary>
public class MusicTransitionScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    private void Start() //Set Default Volume
    {
        audioMixer.SetFloat("MusicTransitionVolume", 0);
    }
    public void Fade() //Public fade action
    {
        StartCoroutine(FadeSeconds());
    }
    private IEnumerator FadeSeconds() //Fade controlled by rate until -80dB
    {
        for (int i = 0; i > -81; i--)
        {
            audioMixer.SetFloat("MusicTransitionVolume", i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
