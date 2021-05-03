using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownHandler : MonoBehaviour
{
    public void HandleInputData(int val) {
    	PlayerPrefs.SetInt("AudioSrc", val);
    	Debug.Log("InputData: " + val);
    }
}
