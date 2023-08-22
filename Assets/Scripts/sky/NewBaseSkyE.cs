using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBaseSkyE : MonoBehaviour
{
    public string nameOfThisObject;

    public Vector3 speed = new Vector3(0, 0, 0);
    public float speedFloat = 7;
    public Vector3 spawnPosition;

    public GameObject seekuhtraktor;
    //public Vector3 applyScoreDifficulty = new Vector3(0f,0f,0f);

    
    public Transform spawnObjLeft;
    public Transform spawnObjRight;
    public Transform spawnObjUp;
    public Transform spawnObjDown;


    protected Transform _trans;
    protected GameObject _gen;
    protected Renderer _renderer;
    protected bool _wasOnScreen;
    protected GameObject _mainObj;
    protected Vars _mainVars;

    public int spotInArray = 0;
    public int direction = 0;


    
    protected void Start()
    {
        spawnObjLeft = GameObject.Find("GenParent/genLeft").GetComponent<Transform>();
        spawnObjRight = GameObject.Find("GenParent/genRight").GetComponent<Transform>();
        spawnObjUp = GameObject.Find("GenParent/genUp").GetComponent<Transform>();
        spawnObjDown = GameObject.Find("GenParent/genDown").GetComponent<Transform>();

        _trans = gameObject.GetComponent<Transform>();
        _gen = GameObject.Find("GenParent");
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
        /*direction = Random.Range(0,4);
        switch (direction) {
            case 0:  speed = new Vector3 (speedFloat, 0f, 0f); spawnPosition = spawnObjLeft.position; break;
            case 1:  speed = new Vector3 (-speedFloat, 0f, 0f); spawnPosition = spawnObjRight.position; break;
            case 2:  speed = new Vector3 (0f, speedFloat, 0f); spawnPosition = spawnObjUp.position; break;
            case 3:  speed = new Vector3 (0f, -speedFloat, 0f); spawnPosition = spawnObjLeft.position; break;
            default: Debug.Log("LOL"); break;
        }*/

        //Debug.Log(spawnPosition + " " + direction);
        //_trans.position = spawnPosition;

    }

    protected void Enable()
    {
        seekuhtraktor = GameObject.Find("Seekuhtraktor");
        _wasOnScreen = false;
        spawnObjLeft = GameObject.Find("GenParent/genLeft").GetComponent<Transform>();
        spawnObjRight = GameObject.Find("GenParent/genRight").GetComponent<Transform>();
        spawnObjUp = GameObject.Find("GenParent/genUp").GetComponent<Transform>();
        spawnObjDown = GameObject.Find("GenParent/genDown").GetComponent<Transform>();
        _trans = gameObject.GetComponent<Transform>();
        


    }

    public void ActivateEnemy() {
        //print("activated");
        //switch (direction) {
            /*case 0:  speed = new Vector3 (speedFloat, 0f, 0f); break;
            case 1:  speed = new Vector3 (-speedFloat, 0f, 0f); break;
            case 2:  speed = new Vector3 (0f, speedFloat, 0f); break;
            case 3:  speed = new Vector3 (0f, -speedFloat, 0f); break;*/
            /*case 0:  speed = new Vector3 (speedFloat, 0f, 0f); spawnPosition = spawnObjLeft.position; break;
            case 1:  speed = new Vector3 (-speedFloat, 0f, 0f); spawnPosition = spawnObjRight.position; break;
            case 2:  speed = new Vector3 (0f, speedFloat, 0f); spawnPosition = spawnObjUp.position; break;
            case 3:  speed = new Vector3 (0f, -speedFloat, 0f); spawnPosition = spawnObjLeft.position; break;
            default: Debug.Log("LOL"); break;
        }*/

        switch (direction) {
            case 0: spawnPosition = spawnObjLeft.position; break;
            case 1: spawnPosition = spawnObjRight.position; break;
            case 2: spawnPosition = spawnObjUp.position; break;
            case 3: spawnPosition = spawnObjLeft.position; break;
            default: Debug.Log("LOL"); break;
        }
        
        _trans.position = spawnPosition;
        speed = Vector3.Normalize(seekuhtraktor.transform.position - _trans.position)*speedFloat;


    }

    protected void Disable()
    {
        _wasOnScreen = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3 (0f,0f,0f);
        gameObject.active = false;
        
    }
    
    protected void Update()
    {
        //applyScoreDifficulty = new Vector3(Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f,0f,0f);
        //_trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;
        //_trans.position += (speed) * Time.deltaTime;
        _mainVars.isEnemyOnScreen[spotInArray] = true;
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = speed;
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
        if(other.gameObject.CompareTag("BoundVert")) 
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
    }

    public void SetDirLeft() {
        //print("SetDirLeft");
        direction = 0;
        spawnPosition = spawnObjLeft.position;
    }
    public void SetDirRight() {
        //print("SetDirRight");
        direction = 1;
        spawnPosition = spawnObjRight.position;
    }
    public void SetDirUp() {
        //print("SetDirUp");
        direction = 3;
        spawnPosition = spawnObjUp.position;
    }
    public void SetDirDown() {
        //print("SetDirDown");
        direction = 2;
        spawnPosition = spawnObjDown.position;
    }
    
    /*public void OverrideSpawnPosition() {
        //if (spawnPosition == new Vector3(0f,0f,0f)) {
        direction = Random.Range(0,4);
        switch (direction) {
        case 0:  speed = new Vector3 (speedFloat, 0f, 0f); spawnPosition = spawnObjLeft.position; break;
        case 1:  speed = new Vector3 (-speedFloat, 0f, 0f); spawnPosition = spawnObjRight.position; break;
        case 2:  speed = new Vector3 (0f, speedFloat, 0f); spawnPosition = spawnObjUp.position; break;
        case 3:  speed = new Vector3 (0f, -speedFloat, 0f); spawnPosition = spawnObjLeft.position; break;
        default: Debug.Log("LOL"); break;
        }
        //}     
    }*/
}
