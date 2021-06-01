using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBaseEnemy : MonoBehaviour
{
    public string nameOfThisObject;

    public Vector3 speed = new Vector3(-8f, 0, 0);
    public Vector3 spawnPosition;
    public Vector3 applyScoreDifficulty = new Vector3(0f,0f,0f);

    protected Transform _trans;
    protected GameObject _gen;
    protected Renderer _renderer;
    protected bool _wasOnScreen;
    protected GameObject _mainObj;
    protected Vars _mainVars;

    public int spotInArray = 0;
    
    protected void Start()
    {
        _trans = gameObject.GetComponent<Transform>();
        _gen = GameObject.Find("Generate");
        _renderer = GetComponent<Renderer>();
        _mainObj = GameObject.Find("Main");
        _mainVars = _mainObj.GetComponent<Vars>();
        _wasOnScreen = false;

        nameOfThisObject = gameObject.name;
        nameOfThisObject = nameOfThisObject.Remove(name.Length - 7);
        

        for(int i = 0; i < _mainVars.everyEnemyArray.Length; i++)
        {
            //Debug.Log("The element in index " + i + " is " + _mainVars.everyEnemyArray[i]);
            if(_mainVars.everyEnemyArray[i].name == nameOfThisObject) {
                _mainVars.isEnemyOnScreen[i] = true;
                spotInArray = i;
                //Debug.Log("itworked");
            }
        }

        /*foreach(GameObject go in _mainVars.everyEnemyArray)
        {
            Debug.Log(go);
            Debug.Log("ThisOne is " + gameObject.name);
            if(go.name == gameObject.name)
            {
                Debug.Log("ItFits" + go.name);
                break;
            }
        }*/

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
    	applyScoreDifficulty = new Vector3(Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f,0f,0f);
        _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;
        _mainVars.isEnemyOnScreen[spotInArray] = true;

    }

    protected void OnBecameVisible()
    {
        _wasOnScreen = true;
    }

    protected void OnBecameInvisible()
    {
        if (_wasOnScreen && _gen != null) _gen.SendMessage("DisableGO", gameObject);
        _mainVars.isEnemyOnScreen[spotInArray] = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy")) 
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
    }

    public void ManualCheckIfOffscreen(float killPosition) {
        if(_trans.position.x <= killPosition) {
            if (_wasOnScreen && _gen != null) {
                _gen.SendMessage("DisableGO", gameObject); 
                //Debug.Log("ManualDeactivation of GameObject " + nameOfThisObject); 
            }
            _mainVars.isEnemyOnScreen[spotInArray] = false;
                   
            }
    }

    public void MushDelete(GameObject gob) {
        try {
            _mainVars.isEnemyOnScreen[spotInArray] = false;
            GameObject.Find("Generate").SendMessage("DisableGO", gob);
        } 
        catch {
            GameObject.Find("Generate").SendMessage("DisableGO", gob.transform.parent.gameObject);
            Debug.Log("Error + ");
        }
    }

    public void ManualCheckIfOnscreen(float onPosition) {
        if(_trans.position.x >= onPosition) {
            _wasOnScreen = true;
        }
    }
}
