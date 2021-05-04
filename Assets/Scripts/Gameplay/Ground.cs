using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Range(-12f,12f)]
	public float sped = 6f;

    private float offset;
    private Material mat;
    private Renderer rend;

    public GameObject mainObj;
    public Vars mainVars;
    private float score;

    // Start is called before the first frame update
    void Awake()
    {

        mainVars = mainObj.GetComponent<Vars>();
        
    }

    
    void Update()
    {
    	/*
        offset = offset + (Time.deltaTime * sped) / 10;
        
        mat.SetTextureOffset("_MainTex", new Vector3(offset, 0, 0));
		*/
        score = (float) mainVars.scoreInt / 800f;
    	transform.position = transform.position - new Vector3((sped+score)*Time.deltaTime,0,0);
    	if(transform.position.x <= -22.5) {
    		transform.position = new Vector3(-7.5f,transform.position.y,0f);
    	}
    }
}
