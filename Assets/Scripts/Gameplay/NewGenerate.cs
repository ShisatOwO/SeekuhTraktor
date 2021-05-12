using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewGenerate : MonoBehaviour
{
    private Pooler _pooler = new Pooler();
    
    void Start()
    {
        Pooler p1 = _pooler.CreateSiblingPool("Tier1");
        Pooler p2 = _pooler.CreateSiblingPool("Tier2");
        Pooler p3 = p2.CreateSiblingPool("Tier3");
		
		//if (p1.GetSiblingPool("Tier2") != null) Debug.Log("ERFOLG");
		//else Debug.Log("WAS KANNST DU????");

		p1.Add(gameObject);
		//Debug.Log(p3.RequestObj());
		//Debug.Log(p3.RequestObj());
		p3.Add(gameObject);
		//Debug.Log(p2.RequestObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
