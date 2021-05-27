using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erleuchtungg : NewBaseEnemy
{
	

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BoundVert"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }
    }

}
