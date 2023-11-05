using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicTransitionScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    private void Start()
    {
        audioMixer.SetFloat("MusicTransitionVolume", 0);
    }
    public void Fade()
    {
        StartCoroutine(FadeSeconds());
    }
    private IEnumerator FadeSeconds()
    {
        for (int i = 0; i > -81; i--)
        {
            audioMixer.SetFloat("MusicTransitionVolume", i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
