using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedAspectRatio : MonoBehaviour
{
    private Camera cam;
    public bool debugEditor;
    public float debugWidth;
    public float debugHeight;
    private float current_ratio;
    
    void Start()
    {
        float ratio = 16f / 9f;
        if(debugEditor == false) {
        		current_ratio = (float) (Screen.width / Screen.height);
        	} else {
        		current_ratio = (float) (debugWidth / debugHeight);
        	}
        float scaling = (float)(current_ratio / ratio);
        cam = GetComponent<Camera>();

        if (scaling < 1f)
        {
            Rect rect = cam.rect;
            rect.width = 1f;
            rect.height = scaling;
            rect.x = 0;
            rect.y = (1f - scaling) / 2f;
            cam.rect = rect;
        }

        else
        {
            scaling = 1f / scaling;
            Rect rect = cam.rect;
            rect.width = scaling;
            rect.height = 1f;
            rect.x = (1f - scaling) / 2f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
