using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class applyDebugScreenSize : MonoBehaviour
{
    public TMP_InputField debugWidthTMPRO;
    public TMP_InputField debugHeigthTMPRO;
    public FixedAspectRatio mainCamRatio;
    public string dw;
    public string dh;
    public int w;
    public int h;

    // Start is called before the first frame update
    void Update()
    {
        dw = debugWidthTMPRO.text.Trim();
        dh = debugHeigthTMPRO.text.Trim();
        //Debug.Log(""+dw+dh);
    }

    public void UpdateCam() {

        bool success1 = int.TryParse(""+dw, out w);
        bool success2 = int.TryParse(""+dh, out h);

        mainCamRatio.OverrideCam(w,h);

        
    }
    
}
