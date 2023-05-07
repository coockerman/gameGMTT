using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletEnemy : SpawnBullet
{
    [SerializeField] GameObject bullet;
    protected override void SpawnBullets()
    {
        if (bullet == null) return;
        if(bullet.activeSelf == false)
        {
            bullet.transform.position = transform.position + new Vector3(0,0.1f,0);
            bullet.SetActive(true);
        }
        
    }
}
