using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiManagerEnemy : UiManager
{
    public EnemyHealthManager HealthObject;
    public TextMeshProUGUI nameEnm;
    public string nameEnemy;
    
    private void Start()
    {
        HealthObject = gameObject.GetComponent<EnemyHealthManager>();
        nameEnm = GetComponentInChildren<TextMeshProUGUI>();
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
    public void UpdateName(int lv)
    {
        nameEnm.text = nameEnemy + " lv " + lv;
    }
}
