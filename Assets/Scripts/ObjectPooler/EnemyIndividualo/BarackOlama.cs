using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarackOlama : NewBaseEnemy
{
    // Start is called before the first frame update

	public bool reachedSpot;
	public bool endSpot;
	public float auschwenkung;
	public float stopFrame;
    public float steps;

    [Range(-6f,6f)]
    private float exciterSpot;
    private float counter;

    private Vector3 applyVec;
    private float applyScoreDifficultyFloat;

    
    void Enable()
    {
        _wasOnScreen = false;
        _trans = gameObject.GetComponent<Transform>();
        _trans.position = spawnPosition;
        
    }
    

    
    // Update is called once per frame
    void OnBecameVisible()
    {
        _wasOnScreen = true;
        //reachedSpot = false;
        counter = 0f;
        //endSpot = false;
        //exciterSpot = ((float)Random.Range(0,101) / 100f * 12f) - 6f;
        //Debug.Log("exciterSpot" + exciterSpot);

    }
    
    
    void OnBecameInvisible()
    {
        if (_wasOnScreen && _gen != null) _gen.SendMessage("DisableGO", gameObject);
        _mainVars.isEnemyOnScreen[spotInArray] = false;
    }
    
    
    /*
    void Update() {
		
        //if(!reachedSpot || endSpot) {
            applyScoreDifficulty = new Vector3(Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f,0f,0f);
            _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;
        //}

        
        if(!endSpot && _trans.position.x <= exciterSpot ) {
            reachedSpot = true;
            Debug.Log(reachedSpot + " + end + " + endSpot);
        }
        

        if(reachedSpot && !endSpot) {
            counter++;
            _trans.position = new Vector3 (_trans.position.x, spawnPosition.y + (auschwenkung * Mathf.Sin(counter*freq)), 0f);
            if(counter >= stopFrame) {
                endSpot = true;
            }
        }

        _mainVars.isEnemyOnScreen[spotInArray] = true;

    }
    */

    void Update() {
        applyScoreDifficultyFloat = Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f;
        print(auschwenkung * Mathf.Sin(counter*2*3.14159f/steps));
        applyScoreDifficulty = new Vector3(Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f,0f,0f);
        _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;
        _trans.position = new Vector3 (_trans.position.x, spawnPosition.y + (auschwenkung * Mathf.Sin(counter*2*3.14159f/steps)), 0f);


        /*
        applyVec = new Vector3((speed.x - applyScoreDifficultyFloat) * Time.deltaTime, auschwenkung * Mathf.Sin(counter*2*3.14159f/steps), 0f);
        _trans.position += applyVec;
        */
        counter += 1*(float)Random.Range(50,151) / 100f;
        _mainVars.isEnemyOnScreen[spotInArray] = true;

        
    }

}
