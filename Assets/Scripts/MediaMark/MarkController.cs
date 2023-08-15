using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkController : MonoBehaviour
{

    public int lives;
    private int _starting_lives;
    private int _invulframes;

    public bool startFight = false;
    public float velocity;
    public float w;
    public GameObject bulletPrefab;
    public int bulletAmount;
    public GameObject[] bullets;

    private int _rot_frame_border;
    private bool _reset_rot;
    private int _rot_frame_count = 0;

    private int _trans_frame_border;
    private bool _reset_trans;
    private int _trans_frame_count = 0;

    private float _shoot_border;
    private float _shoot_frames_counter;
    private int _count_bullets = 0;
    // Start is called before the first frame update


    void Start()
    {
        _invulframes = 0;
        _shoot_frames_counter = 0;
        _shoot_border = 1;
        _starting_lives = lives;
        _rot_frame_border = Mathf.RoundToInt(Random.Range(0.7f,1f)*30f);
        _reset_rot = false;
        _trans_frame_border = Mathf.RoundToInt(Random.Range(0.8f,1f)*30f);
        _reset_trans = false;
        for (int i = 0; i < bulletAmount; i++) {
            bullets[i] = Instantiate(bulletPrefab, new Vector3(1000,1000,0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startFight) {
            Rotate();
            Translate();
            Shoot();
            _invulframes -= 1;
        }
    }


    void Rotate() {
        if(_reset_rot) {
            _rot_frame_border = Mathf.RoundToInt(Random.Range(0.7f,1f)*300f);
        _reset_rot = false;
        }
        _rot_frame_count += 1;

        if (_rot_frame_count >= _rot_frame_border) {
            _rot_frame_count = 0;
            _reset_rot = true;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-180f,180f)*w;
        }
    }



    void Translate() {
        if(_reset_trans) {
            _trans_frame_border = Mathf.RoundToInt(Random.Range(0.8f,1f)*300f);
        _reset_trans = false;
        }
        _trans_frame_count += 1;

        if (_trans_frame_count >= _trans_frame_border) {
            _trans_frame_count = 0;
            _reset_trans = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f,1f)*velocity,Random.Range(-1f,1f)*velocity);
        }
    }



    void Shoot() {
        print("Lives"+lives/_starting_lives);
        print("Barrier"+_shoot_border);
        _shoot_frames_counter -= 1;
        if ((float) (((float)lives)/(float)_starting_lives) <= _shoot_border && _shoot_frames_counter <= 0) {
            _shoot_frames_counter = 15;
            //if(_count_bullets<= bullets.Length-1) {
            bullets[_count_bullets].transform.position = gameObject.transform.position;
            //_shoot_border -= 1/Mathf.Exp(_count_bullets+1);
            _count_bullets += 1;
            _shoot_border -= 1f/(_count_bullets*_count_bullets+1);
            //}
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && _invulframes <= 0) {
            lives -= 1;
            _invulframes = 15;
        }
    }
}
