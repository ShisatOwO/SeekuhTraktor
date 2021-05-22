using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IQbewarer : MonoBehaviour
{
    // Start is called before the first frame update
    public NewBaseEnemy newBaseEnemyScript;


    private bool baseScriptEnabled = false;


    void Start()
    {
       transform.Rotate (new Vector3 (0, 0, 26.805f)); 
       
    }

    void Update()
    {
    	if(newBaseEnemyScript.enabled && !baseScriptEnabled) {
    		OnBaseScriptEnabled();
    		baseScriptEnabled = true;
    	} 
    	if(!newBaseEnemyScript.enabled) {
    		baseScriptEnabled = false;
    	}
    }

    void OnBaseScriptEnabled() {
    	transform.position += new Vector3(0f, 0.5f, 0f);
    }



}
