using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GandhiSchlange : NewBaseEnemy
{

    void FixedUpdate()
    {
        ManualCheckIfOffscreen(-10.26f);
        ManualCheckIfOnscreen(19.5f);
    }
}
