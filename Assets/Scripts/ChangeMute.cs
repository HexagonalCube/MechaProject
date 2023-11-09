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
    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
    }
    public void Mute (bool mute)
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
