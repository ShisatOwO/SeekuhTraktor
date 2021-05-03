using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class PlayerControllerDesktop : MonoBehaviour
{
    public Vector2 speed;
    
    private PlayerController _playerController;
    private Vector2 _vel;
    void Start()
    {
        _playerController = new PlayerController(this);
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        _vel = new Vector2(speed.x * axisX, speed.y * axisY);
    }

    private void FixedUpdate()
    {
        _playerController.Impulse(_vel);
    }
}
