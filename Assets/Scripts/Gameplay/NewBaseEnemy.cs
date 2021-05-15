using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBaseEnemy : MonoBehaviour
{
    public Vector3 speed = new Vector3(-2f, 0, 0);
    public Vector3 spawnPosition = new Vector3(20f, -3.64f, 0f);
    public Vector3 applyScoreDifficulty = new Vector3(0f,0f,0f);

    private Transform _trans;
    private GameObject _gen;
    private Renderer _renderer;
    private bool _wasOnScreen;
    private GameObject _mainObj;
    private Vars _mainVars;
    
    void Start()
    {
        _trans = gameObject.GetComponent<Transform>();
        _gen = GameObject.Find("Generate");
        _renderer = GetComponent<Renderer>();
        _mainObj = GameObject.Find("Main");
        _mainVars = _mainObj.GetComponent<Vars>();
        _wasOnScreen = false;
    }

    void Enable()
    {
        _wasOnScreen = false;
        _trans = gameObject.GetComponent<Transform>();
        _trans.position = spawnPosition;
    }

    void Disable()
    {
        _wasOnScreen = false;
        gameObject.active = false;
    }
    
    void Update()
    {
    	applyScoreDifficulty = new Vector3(_mainVars.scoreInt/800f,0f,0f);
        _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;

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
