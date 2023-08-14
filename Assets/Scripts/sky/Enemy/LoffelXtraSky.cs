using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoffelXtraSky : NewBaseSkyE
{
    private Vector3 normKnoTransScale;
    // Start is called before the first frame update
    

    public void OnBecameVisible()
    {
        gameObject.transform.rotation = new Quaternion (0f, 0f, Random.Range(-90f,90f), 10f);
        _wasOnScreen = true;
        normKnoTransScale = new Vector3(1f,1f,1f) + new Vector3 (Random.Range(-10f,15f)/10f, Random.Range(-1,2), 0f);
        if(normKnoTransScale.x == 0f || normKnoTransScale.y == 0f) {
            normKnoTransScale.x = 1.1f;
            normKnoTransScale.y = 0.9f;
        }
        transform.localScale = normKnoTransScale;
        Debug.Log("normKnoTransScale" + normKnoTransScale); 
    }
}
