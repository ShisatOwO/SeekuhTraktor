using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Dialog;
using UnityEngine;

public class Phase2_5 : TextLine
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject blindness;
    [SerializeField] private Phase2Controller contrl;
    [SerializeField] private GameObject tb;
    
    public override void speak()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        blindness.SetActive(true);
        contrl.phase3();
        tb.SetActive(false);
    }
}
