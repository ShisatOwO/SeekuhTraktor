using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBaseEnemy : MonoBehaviour
{
    public Vector3 speed = new Vector3(-8f, 0, 0);

    private Transform _trans;
    private GameObject _gen;
    private Renderer _renderer;
    private bool _wasOnScreen;
    
    void Start()
    {
        _trans = gameObject.GetComponent<Transform>();
        _gen = GameObject.Find("Generate");
        _renderer = GetComponent<Renderer>();
        _wasOnScreen = false;
    }

    void Enable()
    {
        _wasOnScreen = false;
        _trans = gameObject.GetComponent<Transform>();
        _trans.position = new Vector3(20f, -3.64f, 0f);
    }

    void Disable()
    {
        _wasOnScreen = false;
        gameObject.active = false;
    }
    
    void Update()
    {
        _trans.position += speed * Time.deltaTime;
    }

    void OnBecameVisible()
    {
        _wasOnScreen = true;
    }

    void OnBecameInvisible()
    {
        if (_wasOnScreen) _gen.SendMessage("Disable", gameObject);
    }

}
