using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LizardBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip spawnSound;

    private bool _firstEnable = true;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position -= new Vector3(0, speed, 0);

        if (this.transform.position.y >= 20)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (_firstEnable) _firstEnable = false;
        else say_nom();
        this.transform.position = new Vector3(Random.Range(-7, 7), 7, 0);
    }

    public void say_nom()
    {
        if (Random.Range(0f, 1f) > 0.7) SoundManager.instance.playOnce(spawnSound);
    }
}
