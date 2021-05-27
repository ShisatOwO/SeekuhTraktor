using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knoflook : NewBaseEnemy
{
	public float auschwenkung;

	
	private float sinCount;

    // Update is called once per frame
    void FixedUpdate()
    {
        sinCount = Time.time;
        //Debug.Log("sinf" + sinCount);
        _trans.position = new Vector3(_trans.position.x, auschwenkung * Mathf.Sin(sinCount*10), 0f);

        
    }
}
