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


	private float spawnRateBorder;
    private Pooler _tier1 = new Pooler();
    private Pooler _tier2 = new Pooler();
    private Pooler _tier3 = new Pooler();
	private float _time;

	private GameObject _mainObj;
    private Vars _mainVars;

	private GameObject CreateObj(GameObject baseObj)
	{
		return Instantiate(baseObj);
	}


	private void Disable(GameObject g)
	{
		g.SendMessage("Disable");
		_tier1.GetSiblingPool(g.name).Add(g);
	}

	private void Enable(GameObject g)
	{
		g.active = true;
		g.SendMessage("Enable");
	}

    void Start()
    {
    	_mainObj = GameObject.Find("Main");
        _mainVars = _mainObj.GetComponent<Vars>();


		//Gegner Generieren (erstmal nur zum Testen)
		foreach (GameObject original in tier1Enemys)
		{
			_tier1.CreateSiblingPool(original.name + "(Clone)");
			for (int i=0; i<poolSize; i++)
			{
				Disable(CreateObj(original));
			}
		}
		_time = 0;
    }

    void Update()
    {
    	applyScoreDifficulty = (float)(_mainVars.scoreInt / 3000f);
    	if(_mainVars.scoreInt < 2000) {applyRandomDifficulty = (float)(Random.Range(-20,21) / 100f); }
    	else if(_mainVars.scoreInt > 2000) {applyRandomDifficulty = (float)(Random.Range(-30,31) / 100f); }
    	/*else if(_mainVars.scoreInt < 4000) {applyRandomDifficulty = (float)(Random.Range(-40,41) / 100f); }
    	else if(_mainVars.scoreInt < 5000) {applyRandomDifficulty = (float)(Random.Range(-50,51) / 100f); }
    	else if(_mainVars.scoreInt > 5000) {applyRandomDifficulty = (float)(Random.Range(-60,61) / 100f); }
    	*/

    	spawnRateBorder = spawnRate - applyScoreDifficulty + applyRandomDifficulty;

		if(Time.time - _time > spawnRateBorder)
		{
			GameObject g = _tier1.RequestObj();
			if (g != null) Enable(g);
			_time = Time.time;
		}
		
    }
}
