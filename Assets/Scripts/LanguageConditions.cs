using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Unused, Changes the language before game launch
/// </summary>
public class LanguageConditions : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TextUpdater textUpdater;
    [SerializeField] DoorsAnimator doors;
    [SerializeField] TutorialType tutorialType;
    public void ChooseLanguage(bool isEnglish) //Changes Prefered language
    {
        textUpdater.isEnglish = isEnglish;
        doors.OpenDoors();
        tutorialType.enabled = true;
        canvas.enabled = false;
    }
}
