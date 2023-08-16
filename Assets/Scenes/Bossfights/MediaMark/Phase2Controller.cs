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
    private float _spawnIntervall;

    [Header("Idk was der Name ist.")] 
    [SerializeField] private GameObject textBox;
    [SerializeField] private List<Zunge> zungen;
    [SerializeField] private int numberOfBullets;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnIntervall;

    private enum Phase
    {
        Starting,
        Attack1,
        Attack2,
    }
    
    void Start()
    {
        _initiateTheGrandVaranPlan = false;
        _totalChange = 0;
        _pool = new LizardBulletPool(numberOfBullets, bulletPrefab);
    }

    void ReleaseTheVaran()
    {
        _initiateTheGrandVaranPlan = true;
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
                
                Debug.Log(_spawnIntervall);
                _spawnIntervall += Time.deltaTime;
                
                break;
            }
        }
    }

    public override void speak()
    {
        ReleaseTheVaran();
        textBox.SetActive(false);
    }

    private void _attack1Setup()
    {
        _phase = Phase.Attack1;

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
        _totalChange += speed;
    }
}
