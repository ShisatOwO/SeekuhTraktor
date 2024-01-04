using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;


public class SkipButton : TextLine
{
    public string currentDialog;
    public GameObject skippedObject;

    public void Skip() {
        //nextLine.speak();
        skippedObject.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}

