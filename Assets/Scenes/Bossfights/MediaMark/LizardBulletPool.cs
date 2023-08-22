using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEditor.SceneTemplate;
using UnityEngine;

public class LizardBulletPool
{
    private List<GameObject> bullets;
    private GameObject pooled;

    public LizardBulletPool(int size, GameObject pooled)
    {
        bullets = new List<GameObject>();
        
        for (int i=0; i<size; i++)
        {
            GameObject bullet = Object.Instantiate(pooled);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    public GameObject Get()
    {
        foreach (var bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        return null;
    }
}
