using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Tutorail trigger segments
/// </summary>
public class TutorialType : MonoBehaviour
{
    //[SerializeField] Collider2D col;
    [SerializeField] TutorialScript tut;
    enum TutorialSegment { Intro, Turns, Dial, Vision, Obstacles, Obstacles2, Objectives, Water, Ammo, Threats, Combat, End}
    [SerializeField] TutorialSegment segment;
    bool starting; //Tutorial start condition.

    void Start() //gets variables
    {
        //col = GetComponent<Collider2D>();
        tut = GetComponentInParent<TutorialScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //Triggers tutorial segments
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (segment)
            {
                case TutorialSegment.Intro:
                    tut.Tutorial1();
                    starting = true;
                    break;
                case TutorialSegment.Turns:
                    tut.Tutorial2();
                    break;
                case TutorialSegment.Dial:
                    tut.Tutorial3();
                    break;
                case TutorialSegment.Vision:
                    tut.Tutorial4();
                    break;
                case TutorialSegment.Obstacles:
                    tut.Tutorial5();
                    break;
                case TutorialSegment.Obstacles2:
                    tut.Tutorial6();
                    break;
                case TutorialSegment.Objectives:
                    tut.Tutorial7();
                    break;
                case TutorialSegment.Water:
                    tut.Tutorial8();
                    break;
                case TutorialSegment.Ammo:
                    tut.Tutorial9();
                    break;
                case TutorialSegment.Threats:
                    tut.Tutorial10();
                    break;
                case TutorialSegment.Combat:
                    tut.Tutorial11();
                    break;
                case TutorialSegment.End:
                    tut.TutorialEnd();
                    break;
            }
        }
    }
    private void Update() //Automatic Start Segment (It works so dont complain about it! I was really drowsy and wanted to go to sleep)
    {
        if (segment == TutorialSegment.Intro && !starting)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 7.5f;
        }
        else if (segment == TutorialSegment.Intro && starting)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
