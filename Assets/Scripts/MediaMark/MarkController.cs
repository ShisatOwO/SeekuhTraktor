using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkController : MonoBehaviour
{
    public AnimationCurve SpawnCurve;
    public GameObject secondPhase;
    private AudioSource audioHurt;
    private AudioSource audioShoot;

    public GameObject plusHundred;
    private int _plusHundred_framecounter;
    public GameObject sfxHurt;
    public GameObject sfxShoot;
    public int lives;
    public GameObject explosion;
    public GameObject scoreObj;
    private ScoreMediaMark _score_script;
    private int _starting_lives;
    private int _invulframes;
    private float _secondsSinceDeath;

    private bool _dead = false;

    public bool startFight = false;
    public float velocity;
    public float w;
    public GameObject bulletPrefab;
    public GameObject bulletHealPrefab;
    public GameObject bulletDiePrefab;
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

    private int _dead_frame_counter;
    // Start is called before the first frame update


    void Start()
    {
        _plusHundred_framecounter = 0;
        audioHurt = sfxHurt.GetComponent<AudioSource>();
        audioShoot = sfxShoot.GetComponent<AudioSource>();
        _score_script = scoreObj.GetComponent<ScoreMediaMark>();
        _dead_frame_counter = 0;
        _dead = false;
        _secondsSinceDeath = 0;
        _invulframes = 1;
        _shoot_frames_counter = 0;
        _shoot_border = 1;
        _starting_lives = lives;
        _rot_frame_border = Mathf.RoundToInt(Random.Range(0.7f,1f)*30f);
        _reset_rot = false;
        _trans_frame_border = Mathf.RoundToInt(Random.Range(0.8f,1f)*30f);
        _reset_trans = false;
        for (int i = 0; i < bulletAmount; i++) {
            if(i == 2 || i == 6 || i == 9 || i == 15 || i == 18 ||i == 25) {
                bullets[i] = Instantiate(bulletDiePrefab, new Vector3(1000,1000,0), Quaternion.identity);
            } else if (i == 7 || i == 11 || i == 20) {
                bullets[i] = Instantiate(bulletHealPrefab, new Vector3(1000,1000,0), Quaternion.identity);
            } else {
                bullets[i] = Instantiate(bulletPrefab, new Vector3(1000,1000,0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startFight && !_dead) {
            Rotate();
            Translate();
            Shoot();
            _invulframes -= 1;

            if (_plusHundred_framecounter > 0) {
                _plusHundred_framecounter -= 1;
                plusHundred.SetActive(true);
            } else {
                plusHundred.SetActive(false);
            }

            if(lives <= 0) {
                _dead = true;
                Die();
            }
        }

        if (_dead) {
            _dead_frame_counter += 1;
            _secondsSinceDeath += Time.deltaTime;
            if(_dead_frame_counter >= 200 && _dead_frame_counter <= 300) {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            /*
            if (_dead_frame_counter >= 1000) {
                explosion.SetActive(false);
            }*/

            if (_secondsSinceDeath >= 4)
            {
                explosion.SetActive(false);
                
            }

            if (_secondsSinceDeath >= 6.5)
            {
                secondPhase.SetActive(true);
                this.gameObject.SetActive(false);
            }
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
        //print("Lives/startting"+lives/_starting_lives);
        //print("Barrier"+_shoot_border);
        try {
            _shoot_frames_counter -= 1;
            if ((float) (((float)lives)/(float)_starting_lives) <= _shoot_border && _shoot_frames_counter <= 0) {
                _shoot_frames_counter = 15;
                //if(_count_bullets<= bullets.Length-1) {
                bullets[_count_bullets].transform.position = gameObject.transform.position;
                audioShoot.Play();
                //_shoot_border -= 1/Mathf.Exp(_count_bullets+1);
                _count_bullets += 1;
                _shoot_border -= SpawnCurve.Evaluate(_count_bullets/30f);
                //}
            }
        } catch (System.IndexOutOfRangeException ex) {
            
        }

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && _invulframes <= 0) {
            lives -= 1;
            audioHurt.Play();
            _score_script.score += 100;
            _invulframes = 300;
            _plusHundred_framecounter = 100;
        }
    }

    void Die() {
        plusHundred.SetActive(false);
        explosion.SetActive(true);
        PlayerPrefs.SetInt("ScoreSceneOverdub", _score_script.score);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        for (int i = 0; i < bullets.Length; i++) {
            bullets[i].SetActive(false);
            
        }
    }
}
