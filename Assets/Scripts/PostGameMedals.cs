using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Post-Game summary, reveals what you've achieved in the last level
/// </summary>
public class PostGameMedals : MonoBehaviour
{
    [SerializeField] TextUpdater textUpdater;
    [SerializeField] Sprite[] medalsSprite = new Sprite[12];
    [SerializeField] Image[] medalsImage = new Image[4];
    // Start is called before the first frame update
    void Start() //Set Default values
    {
        textUpdater.SendTextMessage(" ");
        LoadMedals();
    }

    void LoadMedals() //Loads last level challenges & displays apropriate sprites
    {
        int level = PlayerPrefs.GetInt("LAST") - 1;
        switch (level)
        {
            case 0: //TUTORIAL
                break;
            case 1: //LEVEL1
                if (SaveGame.LoadChallenge(level, 1)) //First challenge
                {
                    medalsImage[0].sprite = medalsSprite[0];
                    medalsImage[0].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 2)) //Second challenge
                {
                    medalsImage[1].sprite = medalsSprite[1];
                    medalsImage[1].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 3)) //Third challenge
                {
                    medalsImage[2].sprite = medalsSprite[2];
                    medalsImage[2].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 4)) //Fourth challenge
                {
                    medalsImage[3].sprite = medalsSprite[3];
                    medalsImage[3].enabled = true;
                }
                break;
            case 2: //LEVEL2
                if (SaveGame.LoadChallenge(level, 1)) //First challenge
                {
                    medalsImage[0].sprite = medalsSprite[4];
                    medalsImage[0].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 2)) //Second challenge
                {
                    medalsImage[1].sprite = medalsSprite[5];
                    medalsImage[1].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 3)) //Third challenge
                {
                    medalsImage[2].sprite = medalsSprite[6];
                    medalsImage[2].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 4)) //Fourth challenge
                {
                    medalsImage[3].sprite = medalsSprite[7];
                    medalsImage[3].enabled = true;
                }
                break;
            case 3: //LEVEL3
                if (SaveGame.LoadChallenge(level, 1)) //First challenge
                {
                    medalsImage[0].sprite = medalsSprite[8];
                    medalsImage[0].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 2)) //Second challenge
                {
                    medalsImage[1].sprite = medalsSprite[9];
                    medalsImage[1].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 3)) //Third challenge
                {
                    medalsImage[2].sprite = medalsSprite[10];
                    medalsImage[2].enabled = true;
                }
                if (SaveGame.LoadChallenge(level, 4)) //Fourth challenge
                {
                    medalsImage[3].sprite = medalsSprite[11];
                    medalsImage[3].enabled = true;
                }
                break;

        }
    }
}
