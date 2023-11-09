using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightChanger : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[7];
    [SerializeField] Image image;
    [SerializeField] bool interactable = true;
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
        interactable = true;
        StartCoroutine(TimedDisable());
    }
    public void HighlightDisable()
    {
        if (interactable)
        {
            image.enabled = false;
            interactable = false;
        }
    }
    private IEnumerator TimedDisable()
    {
        yield return new WaitForSeconds(2);
        interactable = true;
    }
}
