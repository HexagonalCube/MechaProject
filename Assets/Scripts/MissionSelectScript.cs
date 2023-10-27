using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSelectScript : MonoBehaviour
{
    [SerializeField] Animator arrow;
    [SerializeField] Animator slider;
    public int selected = 0;
    [SerializeField] Image b1;
    [SerializeField] Image b2;
    [SerializeField] Image b3;
    [SerializeField] Image b4;
    [SerializeField] Image b5;
    [SerializeField] Sprite red;
    [SerializeField] Sprite white;
    [SerializeField] Image n1;
    [SerializeField] Image n2;
    [SerializeField] Image n3;
    [SerializeField] Image n4;
    [SerializeField] Image n5;
    [SerializeField] Sprite n1W;
    [SerializeField] Sprite n1B;
    [SerializeField] Sprite n2W;
    [SerializeField] Sprite n2B;
    [SerializeField] Sprite n3W;
    [SerializeField] Sprite n3B;
    [SerializeField] Sprite n4W;
    [SerializeField] Sprite n4B;
    [SerializeField] Sprite n5W;
    [SerializeField] Sprite n5B;
    private void Start()
    {
        SelectedUpdate();
    }
    //private void Update()
    //{
    //    SelectedUpdate();
    //}
    private void SelectedUpdate()
    {
        switch (selected)
        {
            case 0:
                slider.Play("mis01");
                b1.sprite = red;
                b2.sprite = white;
                n1.sprite = n1W;
                n2.sprite = n2B;
                break;
            case 1:
                slider.Play("mis02");
                b1.sprite = white;
                b2.sprite = red;
                b3.sprite = white;
                n1.sprite = n1B;
                n2.sprite = n2W;
                n3.sprite = n3B;
                break;
            case 2:
                slider.Play("mis03");
                b2.sprite = white;
                b3.sprite = red;
                b4.sprite = white;
                n2.sprite = n2B;
                n3.sprite = n3W;
                n4.sprite = n4B;
                break;
            case 3:
                slider.Play("mis04");
                b3.sprite= white;
                b4.sprite = red;
                b5.sprite = white;
                n3.sprite = n3B;
                n4.sprite= n4W;
                n5.sprite = n5B;
                break;
            case 4:
                slider.Play("mis05");
                b4.sprite= white;
                b5.sprite = red;
                n4.sprite = n4B;
                n5.sprite = n5W;
                break;
        }
    }

    public void ClickUp()
    {
        arrow.Play("arrowUp");
        if (selected > 0 && selected <= 3)
        {
            selected--;
        }
        SelectedUpdate();
    }
    public void ClickDown()
    {
        arrow.Play("arrowDown");
        if (selected < 3 && selected >= 0)
        {
            selected++;
        }
        SelectedUpdate();
    }
}
