using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraktorCrouch : MonoBehaviour
{
    public Sprite crouch;
    public Sprite normal;
    
    private SpriteRenderer spriteRenderer;
    private bool crouched = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (!crouched) spriteRenderer.sprite = crouch;
        else spriteRenderer.sprite = normal;
        crouched = !crouched;
    }
}
