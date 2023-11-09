using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageScroller : MonoBehaviour
{
    public float speed;
    public float scrollLimit;
    public bool scrollEnabled;
    public RectTransform rectTransform;
    public Vector2 pos1;

    // Update is called once per frame
    private void Update()
    {
        if (scrollEnabled)
        {
            rectTransform.position = new Vector2(rectTransform.position.x-speed,pos1.y);
            if (Mathf.Abs(rectTransform.position.x) > scrollLimit)
            {
                rectTransform.position = pos1;
            }
        }
    }
}
