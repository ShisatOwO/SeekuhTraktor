using System.Collections;
using System.Collections.Generic;
using Dialog;
using UnityEngine;


public class Phase2Controller : TextLine
{
    // Start is called before the first frame update

    private bool _initiateTheGrandVaranPlan;
    private Phase _phase;
    private float _totalChange;
    private LizardBulletPool _pool;
    private LizardBulletPool _tailPool;
    private float _spawnIntervall;
    private float _tailSpawnIntervall;
    private int _tailCount;

    [Header("Idk was der Name ist.")] 
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject endTextBox;
    [SerializeField] private GameObject textBox2;
    [SerializeField] private List<Zunge> zungen;
    [SerializeField] private int numberOfBullets;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnIntervall;
    [SerializeField] private int numberOfTails;
    [SerializeField] private GameObject tailPrefab;
    [SerializeField] private float tailSpawnIntervall;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject blindness;

    [SerializeField] private GameObject lives;

    private bool _isBlind;

    public GameObject scoreAdder;

    private enum Phase
    {
        Starting,
        Attack1,
        Attack2,
        Idle,
    }
    
    void Start()
    {
        _initiateTheGrandVaranPlan = false;
        _totalChange = 0;
        _tailCount = 0;
        _isBlind = false;
        _tailSpawnIntervall = 0;
        _pool = new LizardBulletPool(numberOfBullets, bulletPrefab);
        _tailPool = new LizardBulletPool(numberOfTails, tailPrefab);
    }

    void ReleaseTheVaran()
    {
        _initiateTheGrandVaranPlan = true;
        scoreAdder.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Falls die Zeit noch nicht reif ist...
        if (!_initiateTheGrandVaranPlan) return;

        switch (_phase)
        {
            case Phase.Starting:
            {
                _startingPhase();
                break;
            }

            case Phase.Attack1:
            {
                if (zungen[0].state == Zunge.State.Idle)
                {
                    _phase = Phase.Attack2;
                }

                if (_spawnIntervall >= spawnIntervall)
                {
                    _spawnIntervall = 0;
                    var bullet = _pool.Get();
                }
                
                _spawnIntervall += Time.deltaTime;
                break;
            }

            case Phase.Attack2:
            {
                if (_tailSpawnIntervall >= tailSpawnIntervall)
                {
                    _tailCount++;
                    _tailSpawnIntervall = 0;
                    
                    var tail = _tailPool.Get();
                    
                    if (_tailCount >= numberOfTails)
                    {
                        _phase = Phase.Idle;

                        if (_isBlind)
                        {
                            this.gameObject.SetActive(false);
                            player.GetComponent<SpriteRenderer>().enabled = true;
                            blindness.SetActive(false);
                            endTextBox.SetActive(true);
                        }

                        else
                        {
                            textBox2.gameObject.SetActive(true);
                        }

                        _isBlind = true;
                    }
                }

                _tailSpawnIntervall += Time.deltaTime;
                break;
            }

            case Phase.Idle:
            {
                break;
            }
        }
    }

    public override void speak()
    {
        ReleaseTheVaran();
        textBox.SetActive(false);
    }

    public void phase3()
    {
        _attack1Setup();
    }

    private void _attack1Setup()
    {
        _phase = Phase.Attack1;
        _spawnIntervall = 0;
        _tailCount = 0;

        foreach (var zunge in zungen)
        {
            zunge.Attack();
        }
    }

    private void _startingPhase()
    {
        const float speed = 0.1f;
        
        if (_totalChange >= 2.5)
        {
            _attack1Setup();
            return;
        }

        this.transform.position -= new Vector3(0, speed, 0);
        lives.transform.position -= new Vector3(0,0.08f,0);
        _totalChange += speed;
    }
}
