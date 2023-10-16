using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageModel : MonoBehaviour
{
    [SerializeField] Image leftLeg;
    [SerializeField] Image rightLeg;
    [SerializeField] Image leftArm;
    [SerializeField] Image rightArm;
    [SerializeField] Image hull;
    [SerializeField] Image full;
    [SerializeField] bool lL;
    [SerializeField] bool lA;
    [SerializeField] bool rL;
    [SerializeField] bool rA;
    [SerializeField] bool hl;

    private void Start()
    {
        UpdateDisplay();
    }
    public bool DamageRNG()
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
        UpdateDisplay();
        return CheckDeath();
    }
    void TryLL()
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
    void TryRL()
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
    void TryLA()
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
    void TryRA()
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
    void UpdateDisplay()
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
    }
    bool CheckDeath()
    {
        if (lL && rL && lA && rA && hl)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
