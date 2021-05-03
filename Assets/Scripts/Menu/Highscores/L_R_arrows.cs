using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_R_arrows : MonoBehaviour
{
	public bool lButton = false;
	public bool rButton = false;

	public GameObject rButtonObj;
	private L_R_arrows rButtonScript;

	public int currPage = 0;

	public GameObject displayObj;
	public DisplayHighscores displayScript;
    // Start is called before the first frame update
    void Start()
    {
    	displayScript = displayObj.GetComponent<DisplayHighscores>(); 
    	rButtonScript = rButtonObj.GetComponent<L_R_arrows>();  
    }
 	void Update() {

 	}
    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("MouseDown" + currPage);

        if(lButton == true && rButtonScript.currPage > 0) {
        	Debug.Log("shouldchange: " + currPage);
        	rButtonScript.currPage -= 1;
        	displayScript.changePage(rButtonScript.currPage);
        }
        if(rButton == true && currPage < 9) {
        	Debug.Log("Rshouldchange: " + currPage);
        	currPage += 1;
        	displayScript.changePage(currPage);
        }
    }
}
