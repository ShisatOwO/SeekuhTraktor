using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmphiFahrzeug : NewBaseEnemy
{
    public float randomMovementLeft;
    public float randomMovementRight;

    private int cFrames = 0;
    private Rigidbody2D _rb2d;

    void Start()
    {
        base.Start();
        randomMovementLeft *= 8;
        randomMovementRight *= 8;
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        //if(cFrames >= 10) {
            Vector2 _vel = new Vector2(Random.Range(randomMovementLeft, randomMovementRight) * Time.fixedDeltaTime,
                _rb2d.velocity.y);
            _rb2d.velocity = _vel;
            //cFrames = 0;
            //} else {
            //    cFrames++;
           // }
        applyScoreDifficulty = new Vector3(Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f,0f,0f);
        _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;
        _mainVars.isEnemyOnScreen[spotInArray] = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BoundVert"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }
    }
}
