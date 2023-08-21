using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPrimGen : MonoBehaviour
{
    public GameObject go;
    private int dInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        dInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dInt += 1;
        if(dInt >= 5) {
            go.SetActive(true);
        }
    }
}
