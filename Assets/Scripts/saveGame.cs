using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame
{
    const string SAVE_VOLUME = "VOLUME";
    const string SAVE_FSCREEN = "FSCREEN";
    const string SAVE_RESOLUTION = "RESOLUTION";
    const string SAVE_COMPLETE = "COMPLETE";
    const string SAVE_SENSITIVITY = "SENSITIVITY";
    const string SAVE_CON_SENSITIVITY = "CONSENSITIVITY";
    const string SAVE_SELECTEDCLASS = "CLASS";
    const string T = "true";
    const string F = "false";
    public static void SaveVolume(float volume)
    {
        Debug.Log("OpenAccess SaveVolume " + volume);
        PlayerPrefs.SetFloat(SAVE_VOLUME, volume);
    }
    public static float LoadVolume()
    {
        return PlayerPrefs.GetFloat(SAVE_VOLUME, 0.8f);
    }
    public static void SaveFullscreen(bool fullscreen)
    {
        if (fullscreen)
        {
            PlayerPrefs.SetString(SAVE_FSCREEN, T);
        }
        else
        {
            PlayerPrefs.SetString(SAVE_FSCREEN, F);

        }
    }
    public static bool LoadFullscreen()
    {
        return PlayerPrefs.GetString(SAVE_FSCREEN,T) == "true" ? true : false;
    }
    public static void SaveResolutionIndex(int resolution)
    {
        PlayerPrefs.SetInt(SAVE_RESOLUTION, resolution);
    } 
    public static int LoadResolutionIndex()
    {
        return PlayerPrefs.GetInt(SAVE_RESOLUTION,0);
    }
    public static void SaveLevel(bool complete, int level)
    {
        if (complete)
        {
            PlayerPrefs.SetString(SAVE_COMPLETE + level, T);
        }
    }
    public static bool LoadLevel(int level)
    {
        return PlayerPrefs.GetString(SAVE_COMPLETE + level, F) == "true" ? true : false;
    }
    public static void SaveSens(float sensitivity)
    {
        PlayerPrefs.SetFloat(SAVE_SENSITIVITY, sensitivity);
    }
    public static float LoadSens()
    {
        return PlayerPrefs.GetFloat(SAVE_SENSITIVITY, 1);
    }
    public static void SaveConSens(float sensitivity)
    {
        PlayerPrefs.SetFloat(SAVE_CON_SENSITIVITY, sensitivity);
    }
    public static float LoadConSens()
    {
        return PlayerPrefs.GetFloat(SAVE_CON_SENSITIVITY, 1);
    }
    public static void SaveSelectedClass(int selectedClass)
    {
        PlayerPrefs.SetInt(SAVE_SELECTEDCLASS, selectedClass);
    }
    public static int LoadSelectedClass()
    {
        return PlayerPrefs.GetInt(SAVE_SELECTEDCLASS, 0);
    }
}
