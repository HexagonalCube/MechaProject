using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    [SerializeField] int resources;
    public bool active = true;
    [SerializeField] SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (!active) { sprite.color = Color.gray; }
    }
    public int GetResources()
    {
        if (active)
        {
            sprite.color = Color.gray;
            int res = resources;
            resources = 0;
            active = false;
            return res;
        }
        else
        {
            return 0;
        }
    }
}
