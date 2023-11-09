using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialType : MonoBehaviour
{
    [SerializeField] Collider2D col;
    [SerializeField] TutorialScript tut;
    enum TutorialSegment { Intro, Turns, Dial, Vision, Obstacles, Obstacles2, Objectives, Water, Ammo, Threats, Combat, End}
    [SerializeField] TutorialSegment segment;
    bool starting;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        tut = GetComponentInParent<TutorialScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
    private void Update()
    {
        if (segment == TutorialSegment.Intro && !starting)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 3f;
        }
        else if (segment == TutorialSegment.Intro && starting)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
