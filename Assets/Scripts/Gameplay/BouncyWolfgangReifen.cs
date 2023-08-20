using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWolfgangReifen : MonoBehaviour
{
    public float ini_y_vel;
    public float ini_x_vel;

    public GameObject player;
    public BoxCollider2D crouchedColl;
    public BoxCollider2D normPlayerColl;


    void Start() {
        Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), player.gameObject.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), crouchedColl); 
        Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), normPlayerColl); 

        print(gameObject.GetComponent<Collider2D>());
        print(player.gameObject.GetComponent<Collider2D>());
    }

    void OnEnable() {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-ini_x_vel,-ini_y_vel,0);
    }

}
