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

    private Pooler _tier1 = new Pooler();
    private Pooler _tier2 = new Pooler();
    private Pooler _tier3 = new Pooler();
	private float _time;

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
		if(Time.time - _time > spawnRate)
		{
			GameObject g = _tier1.RequestObj();
			if (g != null) Enable(g);
			_time = Time.time;
		}
		
    }
}
