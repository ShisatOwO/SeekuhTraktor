using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

public class spawnLizardEndBullets : TextLine
{
    public TextLine nextLine2;
    private bool _activate = false;
    [SerializeField] private int numberOfBullets;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnIntervall;

    private LizardBulletPool _pool;
    private float _spawnIntervall;

    public override void speak() {
        _activate = true;

        //nextLine2.speak()
    }


    void FixedUpdate() {
        if(_activate) {
            var bullet = _pool.Get();
        }
    }
}
