using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnoXtraScript : MonoBehaviour
{
	private Vector3 normKnoTransScale;
    // Start is called before the first frame update
    void Start()
    {
        normKnoTransScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) + new Vector3 (Random.Range(-1f,2f), Random.Range(-1,2), 0f);
        if(normKnoTransScale.x == 0f || normKnoTransScale.y == 0f) {
            normKnoTransScale.x = 1.1f;
            normKnoTransScale.y = 0.9f;
        }
        transform.localScale = normKnoTransScale;
        Debug.Log("normKnoTransScale" + normKnoTransScale);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
