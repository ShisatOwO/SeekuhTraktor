using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBackButton : MonoBehaviour
{
	public GameObject optMenu;
	public GameObject mainWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown() {
    	mainWindow.SetActive(true);
    	optMenu.SetActive(false);
    }
}
