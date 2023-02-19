using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float EnemyMaxHealth;
    public float EnemyCurrentHealth;

    protected PlayerStats thePlayerStats;
    public int expToGive;
    protected PointSpawn pointSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
        thePlayerStats = FindObjectOfType<PlayerStats>();
        pointSpawn = FindObjectOfType<PointSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDied();
    }
    protected virtual void EnemyDied()
    {
        if (EnemyCurrentHealth <= 0)
        {
            thePlayerStats.AddExperience(expToGive);
            pointSpawn.SpawnEnemy(gameObject);
            Destroy(gameObject);
        }
    }
    public virtual void HurtEnemy(float damageToGive)
    {
        EnemyCurrentHealth -= damageToGive;
    }
    public virtual void SetMaxHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }
}
