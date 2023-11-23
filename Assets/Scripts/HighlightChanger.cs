using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Tutorial Higlight Script
/// </summary>
public class HighlightChanger : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[7]; //Higlight overlays
    [SerializeField] Image image;
    [SerializeField] bool interactable = false;

    void Start() //Get Relevant variables
    {
        image = GetComponent<Image>();
        image.sprite = sprites[5];
        HighlightDisable();
    }
    public void HighlightImage(int type) //Highlights image with target sprite
    {
        image.sprite = sprites[type];
        image.enabled = true;
        interactable = false;
        StartCoroutine(TimedDisable());
    }
    public void HighlightDisable() //Disable Highlight
    {
        if (interactable)
        {
            image.enabled = false;
            interactable = false;
        }
    }
    private IEnumerator TimedDisable() //After timer, Game becomes interactable
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Can Now Disable");
        interactable = true;
    }
}
