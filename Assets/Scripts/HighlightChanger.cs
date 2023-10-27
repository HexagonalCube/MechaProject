using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightChanger : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[6];
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[5];
        HighlightDisable();
    }
    public void HighlightImage(int type)
    {
        image.sprite = sprites[type];
        image.enabled = true;
    }
    public void HighlightDisable()
    {
        image.enabled = false;
    }
}
