using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] bool point1;
    [SerializeField] bool point2;
    [SerializeField] bool point3;
    [SerializeField] bool point4;
    [SerializeField] bool point5;
    [SerializeField] bool point6;
    [SerializeField] bool point7;
    [SerializeField] bool point8;
    [SerializeField] bool point9;
    [SerializeField] bool point10;
    [SerializeField] bool point11;
    [SerializeField] bool point12;
    [SerializeField] TextUpdater text;
    [SerializeField] HighlightChanger highlight;
    [SerializeField] SfxController sfx;
    private void Start()
    {
        sfx = player.GetComponentInChildren<SfxController>();
    }
    public void Tutorial1()
    {
        if (!point1)
        {
            point1 = true;
            highlight.HighlightImage(0);
            text.SetTutorialText(1);
            Debug.Log("Tutorial1");
            sfx.Notification();
        }
    }
    public void Tutorial2()
    {
        if (!point2)
        {
            point2 = true;
            highlight.HighlightImage(1);
            text.SetTutorialText(2);
            Debug.Log("Tutorial2");
            sfx.Notification();
        }
    }
    public void Tutorial3()
    {
        if (!point3)
        {
            point3 = true;
            highlight.HighlightImage(2);
            text.SetTutorialText(3);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial4()
    {
        if (!point4)
        {
            point4 = true;
            highlight.HighlightImage(1);
            text.SetTutorialText(4);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial5()
    {
        if (!point5)
        {
            point5 = true;
            highlight.HighlightImage(1);
            text.SetTutorialText(5);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial6()
    {
        if (!point6)
        {
            point6 = true;
            highlight.HighlightImage(1);
            text.SetTutorialText(6);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial7()
    {
        if (!point7)
        {
            point7 = true;
            highlight.HighlightImage(3);
            text.SetTutorialText(7);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial8()
    {
        if (!point8)
        {
            point8 = true;
            highlight.HighlightImage(1);
            text.SetTutorialText(8);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial9()
    {
        if (!point9)
        {
            point9 = true;
            highlight.HighlightImage(4);
            text.SetTutorialText(9);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial10()
    {
        if (!point10)
        {
            point10 = true;
            highlight.HighlightImage(5);
            text.SetTutorialText(10);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void Tutorial11()
    {
        if (!point11)
        {
            point11 = true;
            highlight.HighlightImage(3);
            text.SetTutorialText(11);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
    public void TutorialEnd()
    {
        if (!point12)
        {
            point12 = true;
            highlight.HighlightImage(1);
            text.SetTutorialText(12);
            Debug.Log("Tutorial3");
            sfx.Notification();
        }
    }
}
