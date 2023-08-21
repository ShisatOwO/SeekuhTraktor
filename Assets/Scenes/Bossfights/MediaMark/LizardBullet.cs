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
    [SerializeField] private bool autoPos;
    [SerializeField] private float nomPercentage;

    private bool _firstEnable = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position -= new Vector3(0, speed, 0);

        if (this.transform.position.y <= -20)
        {
            this.gameObject.SetActive(false);
        }
        
        if (!autoPos) say_nom();
    }

    private void OnEnable()
    {
        if (autoPos)
        {
            if (_firstEnable) _firstEnable = false;
            else say_nom();
            this.transform.position = new Vector3(Random.Range(-7, 7), 7, 0);
        }
    }

    public void say_nom()
    {
        if (Random.Range(0f, 1f) > 1f-nomPercentage) SoundManager.instance.playOnce(spawnSound);
    }

    public void flee(float fleeSpeed)
    {
        speed = -fleeSpeed;
        Vector3 scale = this.transform.localScale;
        nomPercentage = 0;
        scale.x *= -1;
        this.transform.localScale = scale;
    }
}
