using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looongTren : NewBaseEnemy
{
    void FixedUpdate()
    {
        ManualCheckIfOffscreen(-35f);
        ManualCheckIfOnscreen(19.5f);
    }
}
