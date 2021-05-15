using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBaseEnemy : MonoBehaviour
{
    public Vector3 speed = new Vector3(-8f, 0, 0);
    public Vector3 spawnPosition;
    public Vector3 applyScoreDifficulty = new Vector3(0f,0f,0f);

    protected Transform _trans;
    protected GameObject _gen;
    protected Renderer _renderer;
    protected bool _wasOnScreen;
    protected GameObject _mainObj;
    protected Vars _mainVars;
    
    protected void Start()
    {
        _trans = gameObject.GetComponent<Transform>();
        _gen = GameObject.Find("Generate");
        _renderer = GetComponent<Renderer>();
        _mainObj = GameObject.Find("Main");
        _mainVars = _mainObj.GetComponent<Vars>();
        _wasOnScreen = false;
    }

    protected void Enable()
    {
        _wasOnScreen = false;
        _trans = gameObject.GetComponent<Transform>();
        _trans.position = spawnPosition;
    }

    protected void Disable()
    {
        _wasOnScreen = false;
        gameObject.active = false;
    }
    
    protected void Update()
    {
    	applyScoreDifficulty = new Vector3(_mainVars.scoreInt/800f,0f,0f);
        _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;

    }

    protected void OnBecameVisible()
    {
        _wasOnScreen = true;
    }

    protected void OnBecameInvisible()
    {
        if (_wasOnScreen) _gen.SendMessage("Disable", gameObject);
    }
}
