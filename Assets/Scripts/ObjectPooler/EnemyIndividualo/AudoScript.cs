using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudoScript : NewBaseEnemy
{
    void FixedUpdate()
    {
        ManualCheckIfOffscreen(-15f);
        ManualCheckIfOnscreen(19.5f);
    }
}
