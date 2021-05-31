using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reitenderGandhi : NewBaseEnemy
{
	public float xRotate;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(xRotate, 0f, 0f);
        ManualCheckIfOffscreen(-11.8f);
        ManualCheckIfOnscreen(19.5f);

    }
}
