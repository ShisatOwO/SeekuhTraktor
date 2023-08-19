using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class BoundEndController : TextLine
{
    public GameObject right;
    public GameObject top;
    public GameObject left;
    public GameObject bottom;

    public GameObject RaketenTraktor;
    public TextLine nextLineII;
    private bool doStuffOnlyOnce = true;

    public override void speak() {
        RaketenTraktor.gameObject.GetComponent<PlayerRocket>().movementAllowed = false;
        right.GetComponent<BoundEnd>().Activate();
        left.GetComponent<BoundEnd>().Activate();
        top.GetComponent<BoundEnd>().Activate();
        bottom.GetComponent<BoundEnd>().Activate();
    }

    void FixedUpdate() {
        if(doStuffOnlyOnce && !right.GetComponent<BoundEnd>()._activate && right.GetComponent<BoundEnd>()._start && !left.GetComponent<BoundEnd>()._activate && left.GetComponent<BoundEnd>()._start && !top.GetComponent<BoundEnd>()._activate && top.GetComponent<BoundEnd>()._start && !bottom.GetComponent<BoundEnd>()._activate && bottom.GetComponent<BoundEnd>()._start) {
            nextLineII.speak();
            doStuffOnlyOnce = false;
            right.GetComponent<BoundEnd>().DeActivate();
            left.GetComponent<BoundEnd>().DeActivate();
            top.GetComponent<BoundEnd>().DeActivate();
            bottom.GetComponent<BoundEnd>().DeActivate();
        }

    }


    public void ActivateEnd() {
        right.GetComponent<BoundEnd>().ActivateEnd();
        left.GetComponent<BoundEnd>().ActivateEnd();
        top.GetComponent<BoundEnd>().ActivateEnd();
        bottom.GetComponent<BoundEnd>().ActivateEnd();
    }
    
}
