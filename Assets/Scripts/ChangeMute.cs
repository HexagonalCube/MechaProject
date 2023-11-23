using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeMute : MonoBehaviour
{
    [SerializeField] Image m_Image;
    [SerializeField] Sprite normal;
    [SerializeField] Sprite muted;
    [SerializeField] AudioMixer musicMain;
    public bool mutedStatus = false;

    void Start() //sets default values
    {
        m_Image = GetComponent<Image>();
        musicMain.SetFloat("MusicVolume", -5f);
    }
    public void Mute (bool mute) //mutes the music & changes the sprite to muted
    {
        if (mute)
        {
            musicMain.SetFloat("MusicVolume", -80f);
            m_Image.sprite = muted;
            mutedStatus = true;
        }
        else
        {
            musicMain.SetFloat("MusicVolume", -5f);
            m_Image.sprite = normal;
            mutedStatus = false;
        }
    }
}
