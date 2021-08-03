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

    [Range(-6f,6f)]
    private float exciterSpot;
    private float counter;


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
        reachedSpot = false;
        counter = 0f;
        endSpot = false;
        exciterSpot = ((float)Random.Range(0,101) / 100f * 12f) - 6f;
        Debug.Log("exciterSpot" + exciterSpot);

    }

    void OnBecameInvisible()
    {
        if (_wasOnScreen && _gen != null) _gen.SendMessage("DisableGO", gameObject);
        _mainVars.isEnemyOnScreen[spotInArray] = false;
    }
    
    void Update() {

        if(!reachedSpot || endSpot) {
            applyScoreDifficulty = new Vector3(Mathf.Sqrt(_mainVars.scoreInt) * 0.077459f,0f,0f);
            _trans.position += (speed - applyScoreDifficulty) * Time.deltaTime;
        }
        if(!endSpot && _trans.position.x <= exciterSpot ) {
            reachedSpot = true;
            Debug.Log(reachedSpot + " + end + " + endSpot);
        }
        if(reachedSpot && !endSpot) {
            counter++;
            _trans.position = new Vector3 (_trans.position.x, spawnPosition.y + (auschwenkung * Mathf.Sin(counter/48)), 0f);
            if(counter >= stopFrame) {
                endSpot = true;
            }
        }

        _mainVars.isEnemyOnScreen[spotInArray] = true;
    }

}
