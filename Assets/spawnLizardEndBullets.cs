using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class spawnLizardEndBullets : TextLine
{
    public TextLine nextLine2;
    private bool _activate = false;
    public int countBullets;
    public int frameBetween;


    public override void speak() {
        _activate = true;

        //nextLine2.speak()
    }


    void FixedUpdate() {
        if(_activate) {
            
        }
    }
}
