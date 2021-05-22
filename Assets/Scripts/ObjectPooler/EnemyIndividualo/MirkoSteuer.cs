using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirkoSteuer : MonoBehaviour
{
	public NewBaseEnemy newBaseEnemyScript;
	public float rotSpeed = 150f;

    void Start()
    {
        
    }

    void Update()
    {
    	if(newBaseEnemyScript.enabled) {
    		UpdateWhenScriptIsEnabled();
    	} 
    }

    void UpdateWhenScriptIsEnabled() {
    	transform.Rotate (new Vector3 (0, 0, rotSpeed) * Time.deltaTime);
    }
}
