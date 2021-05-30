using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewGenerate : MonoBehaviour
{
	public GameObject[] tier1Enemys;
    public GameObject[] tier2Enemys;
    public GameObject[] tier3Enemys;
    public int[] scoreGaps;
    public int poolSize;
    public float spawnRate;
    public float applyScoreDifficulty = 0f;
    public float applyRandomDifficulty = 0f;

    public GameObject g = null;

    private GameObject[] allEnemys;
    private int spotInArrayObjAboutToBeSpawned;

    protected float spawnRateBorder;
    protected Pooler _tier1 = new Pooler();
	protected Pooler _tier2 = new Pooler();
	protected Pooler _tier3 = new Pooler();
	protected float _time;
	protected GameObject _mainObj;
	protected Vars _mainVars;
	protected float _squareRootScoreApply;

	
	protected private GameObject CreateObj(GameObject baseObj)
	{
		return Instantiate(baseObj);
	}


	protected private void DisableGO(GameObject g)
	{
		if (g != null) 
		{
			Pooler t = _tier1.GetSiblingPool(g.name);
			if (t == null) t = _tier2.GetSiblingPool(g.name);
			if (t == null) t = _tier3.GetSiblingPool(g.name);
			g.SendMessage("Disable");
			t.Add(g);
		}
	}

	protected private void Enable(GameObject g)
	{
		if (g != null)
		{
			g.active = true;
			g.SendMessage("Enable");
		}
	}

	protected void CreateClones(GameObject[] tierl, ref Pooler tierp)
	{
		foreach (GameObject original in tierl)
		{
			tierp.CreateSiblingPool(original.name + "(Clone)");
			for (int i=0; i<poolSize; i++)
			{
				DisableGO(CreateObj(original));
			}
		}
	}

	protected void Start()
    {
		_mainObj = GameObject.Find("Main");
        _mainVars = _mainObj.GetComponent<Vars>();

		CreateClones(tier1Enemys, ref _tier1);
		CreateClones(tier2Enemys, ref _tier2);
		CreateClones(tier3Enemys, ref _tier3);
		_time = 0;

		//Write all enemyTypes into Main Vars
		_mainVars.everyEnemyArray = tier1Enemys.Concat(tier2Enemys.Concat(tier3Enemys).ToArray()).ToArray();
		_mainVars.everyEnemyStringArr = new string[_mainVars.everyEnemyArray.Length];

		for(int i = 0; i < _mainVars.everyEnemyArray.Length; i++)
        {
            //Debug.Log("The element in index " + i + " is " + _mainVars.everyEnemyArray[i]);

            _mainVars.everyEnemyStringArr[i] = _mainVars.everyEnemyArray[i].name;
            //Debug.Log(_mainVars.everyEnemyStringArr[i]);
           
        }
		//Array.Copy(tier1Enemys, _mainVars.everyEnemyArray, tier1Enemys.Length);
		
		//Debug.Log(_mainVars.everyEnemyArray[14]);



		//Erster Gegner spawnt um...
    	spawnRateBorder = 0.5f;
    }
	
	protected void Update()
	{
		if(Time.time - _time >= spawnRateBorder)
		{
			int allowed_tiers = 1;
			int numberOfAllowedEnemys = tier1Enemys.Length;
			
			foreach(var i in scoreGaps)
			{
				if (_mainVars.scoreInt >= i) allowed_tiers++;
				else break;
			}

			if (allowed_tiers > 1) numberOfAllowedEnemys += tier2Enemys.Length;
			if (allowed_tiers > 2) numberOfAllowedEnemys += tier3Enemys.Length;
			
			int randomTier = Random.Range(0, numberOfAllowedEnemys);

			//GameObject g = null;
			if (randomTier >= tier1Enemys.Length + tier2Enemys.Length)
				g = _tier3.GetSiblingPool(tier3Enemys[Random.Range(0, tier3Enemys.Length)].name + "(Clone)").RequestObj();
			else if (randomTier >= tier1Enemys.Length)
				g = _tier2.GetSiblingPool(tier2Enemys[Random.Range(0, tier2Enemys.Length)].name + "(Clone)").RequestObj();
			else g = _tier1.GetSiblingPool(tier1Enemys[Random.Range(0, tier1Enemys.Length)].name + "(Clone)").RequestObj();

			g = _tier2.GetSiblingPool(tier2Enemys[4].name + "(Clone)").RequestObj();

			
			
			//Debug.Log("1" + g);
			GameObject fairG;
			fairG = CheckIfEnemySpawnIsFair();
			g = fairG;

			Enable(g);

			//Feststellen wann der nächste Gegner spawnt
			GenerateNextSpawnBorder();
			_time = Time.time;
		}
		
    }

	void GenerateNextSpawnBorder() {
		_squareRootScoreApply = (float)(Mathf.Sqrt(_mainVars.scoreInt) / 38.72f);
		//Debug.Log("sqaureRootMultiplier: " + _squareRootScoreApply);
		applyScoreDifficulty = _squareRootScoreApply;
    	ApplyRandomDifficultyFunction(); 
		spawnRateBorder = spawnRate - applyScoreDifficulty + applyRandomDifficulty;
	}

	void ApplyRandomDifficultyFunction() {
		if(_mainVars.scoreInt < 2000) {			applyRandomDifficulty = (float)(Random.Range(-30,11) / 100f); }
			else if(_mainVars.scoreInt > 2000) {applyRandomDifficulty = (float)(Random.Range(-20,21) / 100f); }	
	}

	GameObject CheckIfEnemySpawnIsFair() {
		GameObject newObjToSpawn = g;
		Debug.Log("2"  + g);
		/*
		for(int i = 0; i < _mainVars.everyEnemyArray.Length; i++)
        {
            //Debug.Log("The element in index " + i + " is " + _mainVars.everyEnemyArray[i]);
            if(_mainVars.everyEnemyArray[i].name == objAboutToBeSpawned.name + "(Clone)") {
                spotInArrayObjAboutToBeSpawned = i;
            }
        }*/

        //Barack Olama Rules --> Olama, amphi,

        if(g.name == "BarackOlama(Clone)" && _mainVars.isEnemyOnScreen[System.Array.IndexOf(_mainVars.everyEnemyStringArr, "BarackOlama")] == true) {
        	newObjToSpawn = _tier1.GetSiblingPool(tier1Enemys[Random.Range(0, tier1Enemys.Length)].name + "(Clone)").RequestObj();

        } else if (g.name == "BarackOlama(Clone)" && _mainVars.isEnemyOnScreen[System.Array.IndexOf(_mainVars.everyEnemyStringArr, "FlippedAmphiF")] == true) {
        	newObjToSpawn = _tier1.GetSiblingPool(tier1Enemys[Random.Range(0, tier1Enemys.Length)].name + "(Clone)").RequestObj();
        	Debug.Log("wow");
        } 

        //Lochloffel --> amphi
        else if (g.name == "Lochloffel(Clone)" && _mainVars.isEnemyOnScreen[System.Array.IndexOf(_mainVars.everyEnemyStringArr, "FlippedAmphiF")] == true) {
        	newObjToSpawn = _tier1.GetSiblingPool(tier1Enemys[Random.Range(0, tier1Enemys.Length)].name + "(Clone)").RequestObj();
        	Debug.Log("NoAmphiAfterLoffel");
        }


        return newObjToSpawn;


		
	}
}
