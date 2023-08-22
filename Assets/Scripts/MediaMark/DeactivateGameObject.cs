using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public bool fromFunction;
    public GameObject gameObj;
    // Start is called before the first frame update
    void OnEnable() {
        if (!fromFunction) { gameObj.SetActive(false); }
    }

    public void Disable() {
        gameObj.SetActive(false);
    }
}
