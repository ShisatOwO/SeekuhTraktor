using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedAspectRatio : MonoBehaviour
{
    public float debugWidth;
    public float debugHeight;
    public float ratio;

    private Camera cam;
    private float current_ratio;
    
    void Start()
    {
        ratio = 16.0f / 9.0f;
        
        if(!Application.isEditor) 
        {
        	current_ratio = (float)Screen.width / (float)Screen.height;
        } 
        else { 
        	current_ratio = debugWidth / debugHeight;
        	Debug.Log("thisIsTheEditor");
        }
        
        float scaling = (float)(current_ratio / ratio);
        cam = GetComponent<Camera>();

        if (scaling < 1.0f)
        {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaling;
            rect.x = 0f;
            rect.y = (1.0f - scaling) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            scaling = 1.0f / scaling;
            Rect rect = cam.rect;
            rect.width = scaling;
            rect.height = 1.0f;
            rect.x = (1.0f - scaling) / 2.0f;
            rect.y = 0f;
            cam.rect = rect;
        }
    }

    public void OverrideCam(int width, int height) {
        
        debugWidth = (float)width;
        debugHeight = (float)height;
        Debug.Log("w+h"+debugWidth+debugHeight);
        current_ratio = debugWidth / debugHeight;
           
        float scaling = (float)(current_ratio / ratio);
        cam = GetComponent<Camera>();

        if (scaling < 1.0f)
        {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaling;
            rect.x = 0f;
            rect.y = (1.0f - scaling) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            scaling = 1.0f / scaling;
            Rect rect = cam.rect;
            rect.width = scaling;
            rect.height = 1.0f;
            rect.x = (1.0f - scaling) / 2.0f;
            rect.y = 0f;
            cam.rect = rect;
        }
    } 
}
