using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusHundred : MonoBehaviour
{

    private Vector3 pos;

    void Start() {
        pos = gameObject.transform.position;
    }
    // Start is called before the first frame update
   void OnDisable() {
        gameObject.transform.position = pos;
   }


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3 (0f, -0.1f, 0f);
    }
}
