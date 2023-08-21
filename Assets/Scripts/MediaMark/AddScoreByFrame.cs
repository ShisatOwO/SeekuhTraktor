using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreByFrame : MonoBehaviour
{
    public GameObject ScoreTMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTMP.GetComponent<ScoreMediaMark>().score += 1;
    }
}
