using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraktorCrouch : MonoBehaviour
{
    public Sprite crouch;
    public Sprite normal;
    

    public GameObject hat;
    private SpriteRenderer spriteRenderer;
    private bool crouched = false;
    private Vector3 hatPos;
    
    void Start()
    {
        hat.transform.position = new Vector3(2.00999999f,1.92999995f,0);
        hat.transform.eulerAngles = new Vector3(0,0,16.42f);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (!crouched) {
            spriteRenderer.sprite = crouch;
            crouched = true;
            hat.transform.position = new Vector3(0.0900000036f,-0.569999993f,0);
            hat.transform.eulerAngles = new Vector3(0,0,137.77f);
        }
        else { 
            spriteRenderer.sprite = normal;
            hat.transform.position = new Vector3(2.00999999f,1.92999995f,0);
            hat.transform.eulerAngles = new Vector3(0,0,16.42f);
            crouched = false;
        }
    }
}
