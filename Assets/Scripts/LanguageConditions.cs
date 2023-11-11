using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageConditions : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TextUpdater textUpdater;
    [SerializeField] DoorsAnimator doors;
    [SerializeField] TutorialType tutorialType;
    public void ChooseLanguage(bool isEnglish)
    {
        textUpdater.isEnglish = isEnglish;
        doors.OpenDoors();
        tutorialType.enabled = true;
        canvas.enabled = false;
    }
}
