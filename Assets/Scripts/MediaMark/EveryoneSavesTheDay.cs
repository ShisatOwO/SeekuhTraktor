using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class EveryoneSavesTheDay : TextLine
{
    public TextLine nextLineII;
    private bool dsoo = true;
    private int _start = 0;
    public GameObject TextBox;
    public GameObject TextBoxII;
    public GameObject BoundEndController;

    // Start is called before the first frame update
    public override void speak()
    {
        _start += 1;
        TextBox.SetActive(false);
        TextBoxII.SetActive(false);
        if(_start == 2) BoundEndController.GetComponent<BoundEndController>().ActivateEnd();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_start == 1 && gameObject.transform.position.x <= -5) {
            gameObject.transform.position += new Vector3 (0.1f,0,0);
        }
        if(dsoo && _start == 1 && gameObject.transform.position.x > -5) {
            TextBoxII.SetActive(true);
            dsoo = false;
        }
    }
}
