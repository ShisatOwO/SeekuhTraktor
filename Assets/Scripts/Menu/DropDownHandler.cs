using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
	public TMPro.TMP_Dropdown dd;

	void Start() {
		dd.value = PlayerPrefs.GetInt("AudioSrc");
	}


    public void HandleInputData(int val) {
    	PlayerPrefs.SetInt("AudioSrc", val);
    	Debug.Log("InputData: " + val);
    }
}
