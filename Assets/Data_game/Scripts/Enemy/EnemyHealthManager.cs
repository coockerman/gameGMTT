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
    public GameObject VP1;
    public GameObject VP2;
    public GameObject VP3;
    public GameObject manaRecovery;
    public UiManagerEnemy uiManagerEnemy;
    
    protected int ratio;
    protected int ratioVP1;
    public float CreateHPdied;

    int itemBlood;
    int itemMana;
    int itemVP1;
    int itemVP2;
    int itemVP3;
    int itemVP4;
    int itemVP5;
    int itemVP6;

    private void Awake()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
        uiManagerEnemy = GetComponent<UiManagerEnemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyUpHealth = PlayerPrefs.GetFloat("enemyUpHealth" + gameObject.name);
        if(PlayerPrefs.GetInt("enemyLv" + gameObject.name)<=1)
        {
            PlayerPrefs.SetInt("enemyLv" + gameObject.name, 1);
        }
        EnemyMaxHealth = EnemyMaxHealth + EnemyUpHealth;
        SetMaxHealth();
        SetMaxHealth();
        uiManagerEnemy.UpdateName(PlayerPrefs.GetInt("enemyLv" + gameObject.name));
        CheckTiLeRoiVP();

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
            Invoke("HoiSinhEnemy", 10);

            gameObject.SetActive(false);
        }
    }
    protected virtual void DropHealingItem()
    {
        ratio = Random.Range(1, 100);
        CheckTiLeRoiVP();
        if (ratio <= itemBlood)
        {
            Instantiate(bloodRecovery, transform.position, transform.rotation);
        }
        else if (ratio <= itemBlood + itemMana)
        {
            Instantiate(manaRecovery, transform.position, transform.rotation);
        }
        else if (ratio <= itemBlood + itemMana + itemVP1)
        {
            GameObject vp1 = Instantiate(VP1, transform.position, transform.rotation);
            vp1.name = VP1.name;
        }
        else if (ratio <= itemBlood + itemMana + itemVP1 + itemVP2)
        {
            GameObject vp2 = Instantiate(VP2, transform.position, transform.rotation);
            vp2.name = VP2.name;
        }
        else if(ratio <= itemBlood + itemMana + itemVP1 + itemVP2 + itemVP3)
        {
            GameObject vp3 = Instantiate(VP3, transform.position, transform.rotation);
            vp3.name = VP3.name;
        }
    }
    protected virtual void CheckTiLeRoiVP()
    {
        if(EnemyMaxHealth <=55)
        {
            itemBlood = 0;
            itemMana = 0;
            itemVP1 = 100;
        }else if(EnemyMaxHealth < 200)
        {
            itemBlood = 25;
            itemMana = 25;
            itemVP1 = 15;
        }
        else if(EnemyMaxHealth <= 500)
        {
            itemBlood = 20;
            itemMana = 20;
            itemVP1 = 30;
            itemVP2 = 10;
        }else if(EnemyMaxHealth <= 1000)
        {
            itemBlood = 20;
            itemMana = 20;
            itemVP1 = 40;
            itemVP2 = 15;
            itemVP3 = 3;
        }else if(EnemyMaxHealth <= 2000)
        {
            itemBlood = 10;
            itemMana = 15;
            itemVP1 = 45;
            itemVP2 = 20;
            itemVP3 = 5;
        }else if(EnemyMaxHealth <= 3000)
        {
            itemBlood = 5;
            itemMana = 10;
            itemVP1 = 45;
            itemVP2 = 20;
            itemVP3 = 8;
            itemVP4 = 2;
        }else if(EnemyMaxHealth <= 4000)
        {
            itemBlood = 5;
            itemMana = 10;
            itemVP1 = 40;
            itemVP2 = 20;
            itemVP3 = 10;
            itemVP4 = 5;
            itemVP5 = 5;
        }
        else
        {
            itemBlood = 5;
            itemMana = 10;
            itemVP1 = 40;
            itemVP2 = 20;
            itemVP3 = 10;
            itemVP4 = 5;
            itemVP5 = 5;
        }
    }
    protected virtual void HoiSinhEnemy()
    {
        gameObject.SetActive(true);
        EnemyUpHealth += EnemyMaxHealth * CreateHPdied;
        PlayerPrefs.SetFloat("enemyUpHealth" + gameObject.name, EnemyUpHealth);
        PlayerPrefs.SetInt("enemyLv" + gameObject.name, PlayerPrefs.GetInt("enemyLv" + gameObject.name) + 1);
        uiManagerEnemy.UpdateName(PlayerPrefs.GetInt("enemyLv" + gameObject.name));
        
        EnemyMaxHealth *= (1+ CreateHPdied);

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
