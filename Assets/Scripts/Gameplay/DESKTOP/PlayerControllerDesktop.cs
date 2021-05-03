using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class PlayerMovementDesktop : MonoBehaviour
{
    private PlayerController _playerController;
    
    void Start()
    {
        _playerController = new PlayerController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
