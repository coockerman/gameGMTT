using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBullet : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float KhoangCach;
    [SerializeField] float TimeBan;
    bool DangBan;
    float distance;
    
    protected virtual void Update()
    {
        CheckKhoangCach();
    }
    protected virtual void CheckKhoangCach()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (DangBan) return;
        if (distance < KhoangCach)
        {
            DangBan = true;
            Invoke("DuocBan", TimeBan);
            SpawnBullets();
        }
    }
    protected virtual void SpawnBullets()
    {

    }
    void DuocBan()
    {
        DangBan = false;
    }
}
