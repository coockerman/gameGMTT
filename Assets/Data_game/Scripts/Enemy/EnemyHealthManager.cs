using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float EnemyMaxHealth;
    public float EnemyCurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();

        thePlayerStats = FindObjectOfType<PlayerStats>();
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
            Destroy(gameObject);
        }
    }
    public void HurtEnemy(float damageToGive)
    {
        EnemyCurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }
}
