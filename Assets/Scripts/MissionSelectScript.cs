using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Mission Select Animations/States controller
/// </summary>
public class MissionSelectScript : MonoBehaviour
{
    [SerializeField] Animator arrow;
    [SerializeField] Animator slider;
    public int selected = 0;
    bool l0Completed;
    bool l1Completed;
    bool l2Completed;
    [SerializeField] int completed;
    [SerializeField] Image b1;
    [SerializeField] Image b2;
    [SerializeField] Image b3;
    [SerializeField] Image b4;
    [SerializeField] Image b5;
    [SerializeField] Image description;
    [SerializeField] Sprite n1W;
    [SerializeField] Sprite n1B;
    [SerializeField] Sprite n1R;
    [SerializeField] Sprite n2W;
    [SerializeField] Sprite n2B;
    [SerializeField] Sprite n2R;
    [SerializeField] Sprite n3W;
    [SerializeField] Sprite n3B;
    [SerializeField] Sprite n3R;
    [SerializeField] Sprite n4W;
    [SerializeField] Sprite n4B;
    [SerializeField] Sprite n4R;
    [SerializeField] Sprite n5W;
    [SerializeField] Sprite n5B;
    [SerializeField] Sprite n5R;
    [SerializeField] Sprite desc00;
    [SerializeField] Sprite desc01;
    [SerializeField] Sprite desc02;
    [SerializeField] Sprite desc03;
    private void Start() //gets relevant variables
    {
        l0Completed = SaveGame.LoadLevel(1);
        l1Completed = SaveGame.LoadLevel(2);
        l2Completed = SaveGame.LoadLevel(3);
        if (l0Completed) { completed++; b2.sprite = n2B; }
        if (l1Completed) { completed++; b3.sprite = n3B; }
        if (l2Completed) { completed++; b4.sprite = n4B; }
        SelectedUpdate();
    }
    //private void Update()
    //{
    //    SelectedUpdate();
    //}
    private void SelectedUpdate() //Updates the ui to display relevant level info & graphics
    {
        switch (selected)
        {
            case 0:
                slider.Play("mis01");
                description.sprite = desc00;
                b1.sprite = n1R;
                if (l0Completed)
                {
                    b2.sprite = n2B;
                }
                else
                {
                    b2.sprite = n2W;
                }
                break;
            case 1:
                slider.Play("mis02");
                description.sprite = desc01;
                b1.sprite = n1B;
                b2.sprite = n2R;
                if (l1Completed)
                {
                    b3.sprite = n3B;
                }
                else
                {
                    b3.sprite = n3W;
                }
                break;
            case 2:
                slider.Play("mis03");
                description.sprite = desc02;
                b1.sprite = n1B;
                b2.sprite = n2B;
                b3.sprite = n3R;
                if (l2Completed)
                {
                    b4.sprite = n4B;
                }
                else
                {
                    b4.sprite = n4W;
                }
                break;
            case 3:
                slider.Play("mis04");
                description.sprite = desc03;
                b1.sprite = n1B;
                b2.sprite = n2B;
                b3.sprite = n3B;
                b4.sprite = n4R;
                break;
        }
    }

    public void ClickUp() //Changes level selected to the above on the list
    {
        arrow.Play("arrowUp");
        if (selected > 0 && selected <= completed)
        {
            selected--;
        }
        SelectedUpdate();
    }
    public void ClickDown() //Changes level selected to the below on the list
    {
        arrow.Play("arrowDown");
        if (selected < completed && selected >= 0)
        {
            selected++;
        }
        SelectedUpdate();
    }
}
