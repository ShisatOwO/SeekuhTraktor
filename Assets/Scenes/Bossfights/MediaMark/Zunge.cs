using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Zunge : MonoBehaviour
{
    // Start is called before the first frame update

    private State _state;
    private Vector3 _initialPos;
    private Quaternion _initialRot;
    
    public State state => _state;

    [SerializeField] private float maxRotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float retreatSpeed;
    [SerializeField] private AnimationCurve retreatCurve;
    
    private float _totalRotation;

    public enum State
    {
        Attacking,
        Retreating,
        Idle,
    }
    
    void Start()
    {
        _state = State.Idle;
        _initialPos = this.transform.position;
        _initialRot = this.transform.rotation;
        _totalRotation = 0;
    }

    public void Attack()
    {
        if (_state == State.Idle) _state = State.Attacking;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (_state)
        {
            case State.Attacking:
            {
                if (_totalRotation >= maxRotation)
                {
                    attackSpeed *= -1;
                    rotationSpeed *= -1;
                    _state = State.Retreating;
                    break;
                }
                
                this.transform.Rotate(new Vector3(0, 0, rotationSpeed));
                this.transform.localPosition += new Vector3(attackSpeed, 0, 0);

                _totalRotation += math.abs(rotationSpeed);
                break;
            }

            case State.Retreating:
            {
                float rot = rotationSpeed * retreatSpeed * retreatCurve.Evaluate(_totalRotation/maxRotation);
                float pos = attackSpeed * retreatSpeed * retreatCurve.Evaluate(_totalRotation/maxRotation);
                
                if (_totalRotation < 0)
                {
                    attackSpeed *= -1;
                    rotationSpeed *= -1;
                    _state = State.Idle;
                    break;
                }
                
                this.transform.Rotate(new Vector3(0, 0, rot));
                this.transform.localPosition += new Vector3(pos, 0, 0);

                _totalRotation -= math.abs(rot);
                break;
            }
            
            case State.Idle:
            {
                this.transform.position = _initialPos;
                this.transform.rotation = _initialRot;
                this._totalRotation = 0;
                break;
            }
                
            default:
            {
                break;
            }
        }
    }
}
