using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreepyTailController : MonoBehaviour
{
    [SerializeField] private AnimationCurve heightVariance;
    [SerializeField] private float maxVariance;
    [SerializeField] private int damping;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPos;

    private static float _count = 0;

    //public float Count => _count;

    private void Start()
    {
        _count = 0;
    }

    void OnEnable()
    {
        float variance = (heightVariance.Evaluate(_count/damping)-1f) * maxVariance;
        this.transform.position = startPos + new Vector3(0, variance, 0);
        _count++;
        Debug.Log(_count);
        Debug.Log((heightVariance.Evaluate(_count / damping) - 1f)); // * maxVariance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position -= new Vector3(speed, 0, 0);

        if (_count >= damping)
        {
            _count = 0;
        }
        
        if (this.transform.position.x <= -40)
        {
            this.gameObject.SetActive(false);
        }
    }
}
