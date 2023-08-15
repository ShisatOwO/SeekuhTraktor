using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaBullet : MonoBehaviour
{
    public GameObject _player;
    //ublic Collider 

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("RaketenTraktor");
        print(GetComponent<CircleCollider2D>());
        print(_player.GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), _player.GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(_player.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
