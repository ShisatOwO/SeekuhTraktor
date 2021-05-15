using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmphiFahrzeug : NewBaseEnemy
{
    public float randomMovementLeft;
    public float randomMovementRight;

    private Rigidbody2D _rb2d;

    void Start()
    {
        base.Start();
        randomMovementLeft *= 100;
        randomMovementRight *= 100;
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void FixedUpdate()
    {
        Vector2 _vel = new Vector2(Random.Range(randomMovementLeft, randomMovementRight) / 100 * Time.deltaTime,
            _rb2d.velocity.y);
        _rb2d.velocity = _vel;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BoundVert"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }
    }
}
