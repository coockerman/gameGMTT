using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManagerEnemy : UiManager
{
    public EnemyHealthManager HealthObject;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthObject = gameObject.GetComponent<EnemyHealthManager>();

        healthBar.maxValue = HealthObject.EnemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        NowHealth();
    }
    protected override void NowHealth()
    {
        healthBar.value = HealthObject.EnemyCurrentHealth;
    }
}
