using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBulletController : MonoBehaviour
{
    // Start is called before the first frame update

    private LizardBullet[] bullets;

    void Start()
    { 
        bullets = GetComponentsInChildren<LizardBullet>();    
    }

    public void flee()
    {
        foreach (LizardBullet bullet in bullets)
        {
            bullet.flee(0.1f);
        }
    }
}
