using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class PlayerMovementAndroid : MonoBehaviour
{
    // Start is called before the first frame update

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
