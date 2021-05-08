using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGenScript : MonoBehaviour
{
	private GameObject _mainObj;
	private Vars _mainVars;
	private float _spawnCount;
	private float _spawnBorder;
	private string _enemyName;
	private GameObject _Spawn;
	public string[] EnemyArray;

	[Header("Enemys")]
	public GameObject eGan;
	public GameObject eIQ;
	public GameObject eLof;
    // Start is called before the first frame update
    void Start()
    {
        _mainObj = GameObject.FindWithTag("Main");
        _mainVars = _mainObj.GetComponent<Vars>();
        _spawnBorder = 300f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _spawnCount = _spawnCount + (100*Time.fixedDeltaTime);

        if(_spawnCount >= _spawnBorder) {
        	SpawnFunction(Random.Range(0, 3));
        	_spawnCount = 0;
        }
        
    }

    void SpawnFunction(int whichOne) {

    	_enemyName = EnemyArray[whichOne];
    	
    	switch (_enemyName) {
    		case "gan":
    			_Spawn = Instantiate(eGan, transform.position, Quaternion.identity) as GameObject;
    			break;
    		case "iq":
    			_Spawn = Instantiate(eIQ, transform.position, Quaternion.identity) as GameObject;
    			break;
    		case "lof":
    			_Spawn = Instantiate(eLof, transform.position, Quaternion.identity) as GameObject;
    			break;

    	}

    	Debug.Log(_Spawn);
    	_spawnBorder = 300f - (_mainVars.scoreInt / 100);
    	Debug.Log("nextBorder: " + _spawnBorder);
    	
    }
}
