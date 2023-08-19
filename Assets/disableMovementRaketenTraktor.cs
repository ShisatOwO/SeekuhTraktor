using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableMovementRaketenTraktor : MonoBehaviour
{
    public GameObject RaketenTraktor;
    private Vector3 zero = new Vector3(0,-3f,0);
    private Vector3 _rT_pos;
    private Vector3 dir;
    private bool start = false;

    private int fcount;
    // Start is called before the first frame update
    void Start()
    {
        _rT_pos = RaketenTraktor.gameObject.transform.position;
        dir = (zero - _rT_pos) * 0.01f;
    }

    void OnEnable() {
        start = true;
        RaketenTraktor.gameObject.GetComponent<PlayerRocket>().movementAllowed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(fcount < 100 && start) {
            RaketenTraktor.gameObject.transform.position += dir;
            fcount += 1;
        }

    }
}
