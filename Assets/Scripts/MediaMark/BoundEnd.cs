using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundEnd : MonoBehaviour
{
    public bool _activate;
    public bool _start;
    public bool left;
    public bool top;
    public bool right;
    public bool bottom;

    private bool _activateEnd = false;

    public GameObject rightObj;
    public GameObject topObj;
    public GameObject leftObj;
    public GameObject bottomObj;

    public float speed;


    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        speed = -0.02f;
        _start = false;
        _activate = false;
        collider = gameObject.GetComponent<Collider2D>(); 


    }

    public void ActivateEnd() {
        _activateEnd = true;
    }

    public void Activate() {
        _activate = true;
        _start = true;

    }

    public void DeActivate() {
        _activate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if(_activate && _start){
            if(left) gameObject.transform.position += new Vector3(-0*speed*1.5f,0,0);
            if(top) gameObject.transform.position += new Vector3(0,0*speed,0);
            if(right) gameObject.transform.position += new Vector3(0*speed*1.5f,0,0);
            if(bottom) gameObject.transform.position += new Vector3(0,-0*speed,0);
        }*/
        if(_activateEnd){
            if(left) gameObject.transform.position += new Vector3(5*speed*1.5f,0,0);
            if(top) gameObject.transform.position += new Vector3(0,-5*speed,0);
            if(right) gameObject.transform.position += new Vector3(-5*speed*1.5f,0,0);
            if(bottom) gameObject.transform.position += new Vector3(0,5*speed,0);
        }
    }


    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && _start && !_activateEnd) {
            _activate = false;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && _start && !_activateEnd) {
            _activate = true;
        }
    }
}
