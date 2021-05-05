using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class PlayerControllerDesktop : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float jumpForce;
    
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = new PlayerController(this, jumpForce, maxSpeed, acceleration);
    }

    private void Update()
    {
        float rl = Input.GetAxis("Horizontal");
        bool jmp = Input.GetButton("Jump");
        //bool crh = Input.GetButton("Crouch");
        bool crh = false; // nur als test
        
        _playerController.ReceiveInput(rl, jmp, crh);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerController.PlayerCollision(other);
    }
}
