using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManagerEnemy : UiManager
{
    public EnemyHealthManager HealthObject;

    private void Awake()
    {
        HealthObject = gameObject.GetComponent<EnemyHealthManager>();

    }
    

    // Update is called once per frame
    void Update()
    {
        NowHealth();
    }
    protected override void NowHealth()
    {
        healthBar.maxValue = HealthObject.EnemyMaxHealth;
        healthBar.value = HealthObject.EnemyCurrentHealth;
    }
}
