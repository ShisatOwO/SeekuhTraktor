using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
	private Rigidbody2D rb;
	private int randomNumber;

	public GameObject scoSpedObject;
    public Score scoSpeedScript;
    private int scoreCounterCa;
    private float scoreFLT;
    private string scoreSTR;
    private int scoreINNT;

    public GameObject mainObj;
    public Vars mainVars;
    // Start is called before the first frame update
    void Start()
    {
        mainObj = GameObject.FindWithTag("Main");
        mainVars = mainObj.GetComponent<Vars>();
    	scoSpedObject = GameObject.Find("Canvas/ScoreTMP");
    	scoSpeedScript = scoSpedObject.GetComponent<Score>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

    	scoreCounterCa = scoSpeedScript.score;
    	scoreFLT = scoreCounterCa / 30f;
    	scoreSTR = ""+ scoreFLT;
    	int.TryParse(scoreSTR, out scoreINNT);
    	randomNumber = Random.Range(-4, 11 + scoreINNT);
    	
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-randomNumber, rb.velocity.y, 0f);

        if(transform.position.x >= -10) {
            mainVars.amphOnS = true;
        } else {
            mainVars.amphOnS = false;
        }

        if(transform.position.x <= -15) {
            Destroy(transform.gameObject);
        }
    }
}
