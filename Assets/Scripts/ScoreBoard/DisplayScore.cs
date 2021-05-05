using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = ""+PlayerPrefs.GetInt("ScoreSceneOverdub");
    }
}
