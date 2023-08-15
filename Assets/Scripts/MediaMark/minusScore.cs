using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minusScore : MonoBehaviour
{
    private Vector3 pos;
    public int anzeige;

    void Start() {
        pos = gameObject.transform.position;
    }
    // Start is called before the first frame update
   void OnDisable() {
        anzeige = 0;
        gameObject.transform.position = pos;
   }


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3 (0f, -0.1f, 0f);
    }

}
