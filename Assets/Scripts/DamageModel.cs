using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageModel : MonoBehaviour
{
    [SerializeField] Image leftLeg;
    [SerializeField] Image rightLeg;
    [SerializeField] Image leftArm;
    [SerializeField] Image rightArm;
    [SerializeField] Image hull;
    [SerializeField] Image full;
    [SerializeField] Image destroyed;
    [SerializeField] bool lL;
    [SerializeField] bool lA;
    [SerializeField] bool rL;
    [SerializeField] bool rA;
    [SerializeField] bool hl;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip sfxDeath;
    [SerializeField] AudioClip sfxHit;
    [SerializeField] InteractionHandler interactions;

    private void Start() //Updates the mech damage display
    {
        UpdateDisplay();
    }
    public bool DamageRNG() //Picks a random part of the mech to display as broken
    {
        int rng = Mathf.FloorToInt(UnityEngine.Random.Range(0, 4));
        switch (rng)
        {
            case 0:
                TryLL();
                break;
            case 1:
                TryRL();
                break;
            case 2:
                TryLA();
                break;
            case 3:
                TryRA();
                break;
        }
        HitFX(CheckDeath());
        UpdateDisplay();
        return CheckDeath();
    }
    void TryLL() //If LL is already damaged, damage next part
    {
        if (!lL)
        {
            lL = true;
        }
        else if (!lA)
        {
            lA = true;
        }
        else if (!rL)
        {
            rL = true;
        }
        else if (!rA)
        {
            rA = true;
        }
        else
        {
            hl = true;
        }
    }
    void TryRL() //If RL is already damaged, damage next part
    {
        if (!rL)
        {
            rL = true;
        }
        else if (!rA)
        {
            rA = true;
        }
        else if (!lL)
        {
            lL = true;
        }
        else if (!lA)
        {
            lA = true;
        }
        else
        {
            hl = true;
        }
    }
    void TryLA() //If LA is already damaged, damage next part
    {
        if (!lA)
        {
            lA = true;
        }
        else if (!lL)
        {
            lL = true;
        }
        else if (!rA)
        {
            rA = true;
        }
        else if (!rL)
        {
            rL = true;
        }
        else
        {
            hl = true;
        }
    }
    void TryRA() //If RA is already damaged, damage next part
    {
        if (!rA)
        {
            rA = true;
        }
        else if (!rL)
        {
            rL = true;
        }
        else if (!lA)
        {
            lA = true;
        }
        else if (!lL)
        {
            lL = true;
        }
        else
        {
            hl = true;
        }
    }
    void UpdateDisplay() //Display current health status
    {
        if (lL)
        {
            leftLeg.enabled = true;
        } else { leftLeg.enabled = false; }
        if (lA)
        {
            leftArm.enabled = true;
        } else { leftArm.enabled = false; }
        if (rL)
        {
            rightLeg.enabled = true;
        } else {  rightLeg.enabled = false; }
        if (rA)
        {
            rightArm.enabled = true;
        } else { rightArm.enabled = false; }
        if (hl)
        {
            full.enabled = true;
        } else { full.enabled = false; hull.enabled = false; }
        destroyed.enabled = CheckDeath();
    }
    bool CheckDeath() //Checks if player dead/if all parts damaged
    {
        if (lL && rL && lA && rA && hl)
        {
            StartCoroutine(DeathCountdown());
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator DeathCountdown() //Gives time to quit
    {
        yield return new WaitForSecondsRealtime(3);
        interactions.Quit();
    }
    void HitFX(bool death) //Plays relevant sfx when player hit/dead
    {
        sfx.Stop();
        if (!death)
        {
            sfx.PlayOneShot(sfxHit);
        }
        else
        {
            sfx.PlayOneShot(sfxDeath);
        }
    }
}
