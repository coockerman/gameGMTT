using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float EnemyMaxHealth;
    public float EnemyCurrentHealth;
    public float EnemyUpHealth;

    protected PlayerStats thePlayerStats;
    public int expToGive;

    public GameObject bloodRecovery;
    protected int ratio;

    private void Awake()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();

    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyUpHealth = PlayerPrefs.GetFloat("enemyUpHealth" + gameObject.name);
        EnemyMaxHealth += EnemyUpHealth;
        EnemyCurrentHealth = EnemyMaxHealth;
        SetMaxHealth();
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
            DropHealingItem();
            Invoke("HoiSinhEnemy", 3);

            gameObject.SetActive(false);
        }
    }
    protected virtual void DropHealingItem()
    {
        ratio = Random.Range(1, 10);
        if(ratio <= 3)
        {
            Instantiate(bloodRecovery, transform.position, transform.rotation);
        }
    }
    protected virtual void HoiSinhEnemy()
    {
        gameObject.SetActive(true);
        EnemyUpHealth += EnemyMaxHealth *= 0.2f;
        PlayerPrefs.SetFloat("enemyUpHealth" + gameObject.name, EnemyUpHealth);
        EnemyMaxHealth *= 1.2f;
        
        EnemyCurrentHealth = EnemyMaxHealth;
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
