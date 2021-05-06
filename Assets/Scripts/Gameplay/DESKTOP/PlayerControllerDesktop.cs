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
    public float jumpHeight;
    public float airMobility;
    public float acceleration;
    public float deceleration;
    
    private PlayerController _playerController;
    private int _rl;
    private bool _isMoving;
    private bool _jmp;
    private bool _crh;
    
    private void Start()
    {
        _playerController = new PlayerController(this, jumpForce, jumpHeight, airMobility, maxSpeed, acceleration, deceleration);
    }

    private void Update()
    {
        _rl = 0;
        if (Input.GetButton("Right") || Input.GetAxisRaw("Horizontal") > 0) _rl = 1;
        else if (Input.GetButton("Left") ||  Input.GetAxisRaw("Horizontal") < 0) _rl = -1;
        _jmp = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        _playerController.Move(_rl, _jmp, false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerController.PlayerCollision(other);
    }
}
