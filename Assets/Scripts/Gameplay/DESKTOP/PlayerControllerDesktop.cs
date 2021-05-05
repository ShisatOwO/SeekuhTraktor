using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
using UnityEngine.Assertions.Must;

public class PlayerControllerDesktop : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;
    public float acceleration;
    public float deceleration;
    
    private PlayerController _playerController;
    private float _rl;
    private bool _jmp;
    private bool _crh;
    
    private void Start()
    {
        _playerController = new PlayerController(this, jumpForce, maxSpeed, acceleration, deceleration);
    }

    private void Update()
    {
        _rl = Input.GetAxis("Horizontal");
        _jmp = Input.GetButton("Jump");
        //bool crh = Input.GetButton("Crouch");
        _crh = false; // nur als test
    }

    private void FixedUpdate()
    {
        _playerController.Move(_rl, _jmp, _crh);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerController.PlayerCollision(other);
    }
}
