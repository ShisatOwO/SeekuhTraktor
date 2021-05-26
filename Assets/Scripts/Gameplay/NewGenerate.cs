using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    protected GameObject[][] _enemys;
    protected float spawnRateBorder;
    protected Pooler _tier1 = new Pooler();
	protected Pooler _tier2 = new Pooler();
	protected Pooler _tier3 = new Pooler();
	protected Pooler[] _tiers;
	protected float _time;
	protected GameObject _mainObj;
	protected Vars _mainVars;
	protected float _squareRootScoreApply;

	protected private GameObject CreateObj(GameObject baseObj)
	{
		return Instantiate(baseObj);
	}


	protected private void Disable(GameObject g)
	{
		g.SendMessage("Disable");
		Pooler t = _tier1.GetSiblingPool(g.name);
		if (t == null) t = _tier2.GetSiblingPool(g.name);
		if (t == null) _tier3.GetSiblingPool(g.name);
		t.Add(g);
	}

	protected private void Enable(GameObject g)
	{
		g.active = true;
		g.SendMessage("Enable");
	}

	protected void CreateClones(GameObject[] tierl, ref Pooler tierp)
	{
		foreach (GameObject original in tierl)
		{
			tierp.CreateSiblingPool(original.name + "(Clone)");
			for (int i=0; i<poolSize; i++)
			{
				Disable(CreateObj(original));
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

		//Erster Gegner spawnt um...
    	spawnRateBorder = 0.5f;

        _enemys = new GameObject[3][] { tier1Enemys,
										tier2Enemys,
										tier3Enemys };
        
        
        _tiers = new Pooler[3] { _tier1,
								_tier2,
								_tier3 };
    }

	protected GameObject GetRandomEnemy()
	{
		int acceptedTiers = 1;
		int numberOfEnemys = _tier1.GetNumberOfSiblingPools();
		foreach (int i in scoreGaps)
		{
			if (_mainVars.scoreInt > i)
			{
				numberOfEnemys += _tiers[acceptedTiers].GetNumberOfSiblingPools();
				acceptedTiers++;
			};
		}

		int outIndex = Random.Range(0, numberOfEnemys);
		
		int checkedEnemys = 0;
		acceptedTiers = 0;
		foreach (var tier in _tiers)
		{
			if (tier.GetNumberOfSiblingPools() + checkedEnemys < outIndex)
			{
				checkedEnemys += tier.GetNumberOfSiblingPools();
			}
			else
			{
				Debug.Log(tier.GetNumberOfSiblingPools());
				Debug.Log(outIndex - checkedEnemys);
				return tier.GetSiblingPool(_enemys[acceptedTiers][outIndex - checkedEnemys].name + "(Clone)").RequestObj();
			}

			acceptedTiers++;
		}

		return null;
	}
	
	protected void Update()
	{
		if(Time.time - _time >= spawnRateBorder)
		{
			
			
			

			GameObject g = GetRandomEnemy();
			if (g != null) Enable(g);


			//Feststellen wann der nächste Gegner spawnt
			GenerateNextSpawnBorder();
			_time = Time.time;
		}
		
    }

	void GenerateNextSpawnBorder() {
		_squareRootScoreApply = (float)(Mathf.Sqrt(_mainVars.scoreInt) / 38.72f);
		Debug.Log("sqaureRootMultiplier: " + _squareRootScoreApply);
		applyScoreDifficulty = _squareRootScoreApply;
    	ApplyRandomDifficultyFunction(); 
		spawnRateBorder = spawnRate - applyScoreDifficulty + applyRandomDifficulty;
	}

	void ApplyRandomDifficultyFunction() {
		if(_mainVars.scoreInt < 2000) {			applyRandomDifficulty = (float)(Random.Range(-30,11) / 100f); }
			else if(_mainVars.scoreInt > 2000) {applyRandomDifficulty = (float)(Random.Range(-20,21) / 100f); }	
	}
}
