using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerMobile : MonoBehaviour
{

    public Button left;
    public Button right;
    public Button down;
    public Button up;

    public float maxSpeed;
    public float jumpForce;
    public float jumpHeight;
    public float airMobility;
    public float acceleration;
    public float deceleration;
    public Sprite spriteNormal;
    public Sprite spriteCrouch;
    public GameObject fallschirmObject;

    private PlayerController _playerController;
    private int _rl;
    private bool _isMoving;
    private bool _jmp;
    private bool _crh;

    private BtnClicker _lbtn;
    private BtnClicker _rbtn;
    private BtnClicker _ubtn;
    private BtnClicker _dbtn;
    
    private void Start()
    {
        _playerController = new PlayerController(this, 
            jumpForce, 
            jumpHeight, 
            airMobility, 
            maxSpeed, 
            acceleration, 
            deceleration,
            spriteNormal,
            spriteCrouch,
            fallschirmObject);

        _lbtn = left.GetComponent<Button>().GetComponent<BtnClicker>();
        _rbtn = right.GetComponent<Button>().GetComponent<BtnClicker>();
        _ubtn = up.GetComponent<Button>().GetComponent<BtnClicker>();
        _dbtn = down.GetComponent<Button>().GetComponent<BtnClicker>();
    }

    // Update is called once per frame
    void Update()
    {
        _rl = 0;
        _jmp = _ubtn.pressed;
        _crh = false;
        if (_rbtn.pressed) _rl = 1;
        else if (_lbtn.pressed) _rl = -1;
        if (_dbtn.pressed) _crh = true;

        
    }
    
    private void FixedUpdate()
    {
        _playerController.Move(_rl, _jmp, _crh);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.GetComponent<PlayerControllerMobile>().isActiveAndEnabled)
            _playerController.PlayerCollision(other);
    }
}
