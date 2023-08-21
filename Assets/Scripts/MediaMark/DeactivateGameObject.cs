using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public GameObject gameObj;
    // Start is called before the first frame update
    void OnEnable() {
        gameObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
