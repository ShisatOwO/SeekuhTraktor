using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugPreWriteRes : MonoBehaviour
{   
    public FixedAspectRatio mainCamRatio;
    public TMPro.TextMeshProUGUI tmpW;
    public TMPro.TextMeshProUGUI tmpH;
    public float sw;
    public float sh;
    // Start is called before the first frame update
    void Start()
    {
       sw = (float)Screen.width;
       sh = (float)Screen.height;
       tmpH.text = ""+sh;
       tmpW.text = ""+sw;
    }
}


