using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CoolCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AnimationCurve parallaxCurve;
    [SerializeField] private float maxRotation;
    [SerializeField] private float intensity;

    private Vector2 rotation;
    private Vector2 oldRotation;
    
    void Start()
    {
        rotation = Vector2.zero;
    }

    void Update()
    {
        oldRotation = rotation;

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        
        float rotX = parallaxCurve.Evaluate(y * -intensity);
        float rotY = parallaxCurve.Evaluate(x * intensity);

        rotation = new Vector2(rotX, rotY) * maxRotation;

        Vector2 rotateBy = rotation - oldRotation;
        this.transform.Rotate(rotateBy.x, rotateBy.y, 0f);
    }
}
