using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float focusedMovementSpeed;
    [SerializeField] private AudioClip rockethit;
    
    private CircleCollider2D collider;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float moveSpeed;

    public GameObject scoreObj;
    public GameObject minusScore;

    public GameObject livehandlerObj;
    private live_handler _livehandler;

    private TMPro.TextMeshProUGUI minusScoreText;
    private ScoreMediaMark _score_script;
    private int _minus_framecounter = 0;
    private int _minus_anzeige = 0;
    private int _minus_step = 50;

    private int _invulframes;
        
    void Start()
    {
        _livehandler = livehandlerObj.GetComponent<live_handler>();
        _livehandler.loadLives(PlayerPrefs.GetInt("Lives"));
        _invulframes = 100;
        _minus_framecounter = 0;
        minusScoreText = minusScore.GetComponent<TMPro.TextMeshProUGUI>();
        _score_script = scoreObj.GetComponent<ScoreMediaMark>();
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

        _minus_framecounter -= 1;
        if (_minus_framecounter < 0) {
            minusScore.SetActive(false);
            _minus_anzeige = 0;
        } else {
            minusScore.SetActive(true);
        }

        _invulframes -= 1;
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) {

        //_score_script.score += 100;     

        if (other.gameObject.tag == "MediaBullet") {
            //print("collision with bullet");
            if(_minus_framecounter < 0) {
                _minus_framecounter = 100;
            }
            if(_minus_framecounter > 0) {
                _score_script.score -= _minus_step;
                _minus_anzeige -= _minus_step;
                minusScoreText.text = "" + _minus_anzeige;
                
            }

        }

        else if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("MediaBulletDeath"))
        {
            if (_invulframes <= 0)
            {
                _livehandler.removeLive();
                SoundManager.instance.playOnce(rockethit);
            }
            
        }
    }

}
