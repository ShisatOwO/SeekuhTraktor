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


	protected float spawnRateBorder;
	protected Pooler _tier1 = new Pooler();
	protected Pooler _tier2 = new Pooler();
	protected Pooler _tier3 = new Pooler();
	protected float _time;
	protected GameObject _mainObj;
	protected Vars _mainVars;

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
    }

	void getPool(int id, ref Pooler t, ref GameObject[] e)
	{
		t = ref _tier1;
		e = ref tier1Enemys;
		switch (id)
		{
			case 1:
			{
				t = ref _tier2;
				e = ref tier2Enemys;
			} break;
			case 2:
			{
				t = ref _tier3;
				e = ref tier3Enemys;
			} break;
		}
	}
	
	protected void Update()
	{
		Pooler t = _tier1;
		GameObject[] e = tier1Enemys;
	    int acceptedTiers = 0;
		foreach (int i in scoreGaps)
		{
			if (_mainVars.scoreInt > i) acceptedTiers++;
		}

		for (int i = 0; i <= acceptedTiers; i++)
		{
			
			getPool(i, ref t, ref e);
		}
		
		if(Time.time - _time > spawnRateBorder)
		{
			

			GameObject g = t.GetSiblingPool(e[Random.Range(0, e.Length)].name + "(Clone)").RequestObj();
			if (g != null) Enable(g);


			//Feststellen wann der nächste Gegner spawnt
			GenerateNextSpawnBorder();
			_time = Time.time;
		}
		
    }

	void GenerateNextSpawnBorder() {
		applyScoreDifficulty = (float)(_mainVars.scoreInt / 3000f);
    	ApplyRandomDifficultyFunction(); 
		spawnRateBorder = spawnRate - applyScoreDifficulty + applyRandomDifficulty;
	}

	void ApplyRandomDifficultyFunction() {
		if(_mainVars.scoreInt < 2000) {			applyRandomDifficulty = (float)(Random.Range(-20,21) / 100f); }
			else if(_mainVars.scoreInt > 2000) {applyRandomDifficulty = (float)(Random.Range(-30,31) / 100f); }	
	}
}
