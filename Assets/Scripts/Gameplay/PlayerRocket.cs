using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float focusedMovementSpeed;
    
    private CircleCollider2D collider;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float moveSpeed;
        
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        moveDir = Vector2.zero;
        moveSpeed = 0;
    }

    void Update()
    { 
        float deltaX = Input.GetAxisRaw("Horizontal"); 
        float deltaY = Input.GetAxisRaw("Vertical");

        moveSpeed = Input.GetKey("space") ? focusedMovementSpeed : movementSpeed;
        moveDir = new Vector2(deltaX, deltaY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed;
    }
}
