using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform _trans;
    public Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        _trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _trans.position += (speed) * Time.deltaTime;
    }
}
