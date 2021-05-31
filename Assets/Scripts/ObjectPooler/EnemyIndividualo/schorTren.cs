using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schorTren : NewBaseEnemy
{
    void FixedUpdate()
    {
        ManualCheckIfOffscreen(-25f);
        ManualCheckIfOnscreen(19.5f);
    }
}
