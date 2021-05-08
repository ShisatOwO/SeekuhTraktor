using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLoader : MonoBehaviour
{
	private int framesCounter = 0;
	public string enemy;
	public Sprite spritee;
	private bool started = false;
	private Enemy thisEnemyScript;
	private SpriteRenderer thisEnemySprite;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(framesCounter >= 1 && started == false) {
        	LoadEnemy(enemy);
        	started = true;
        } else {
        	if(started == false) {
        		framesCounter++;
        	}
        }
    }

    void LoadEnemy(string enemyName) {
    	switch (enemyName) {
    		case "gan":
    			Debug.Log("GAND LOADED");
    			gameObject.AddComponent<PolygonCollider2D>();
    			thisEnemyScript = gameObject.AddComponent<Enemy>() as Enemy;
    			thisEnemySprite = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
    			thisEnemySprite.sprite = spritee;
    			//thisEnemyScript.bool = true;
    			break;
    	}
    }
}
