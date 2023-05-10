using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public GameObject VP4;
    public GameObject VP5;
    public GameObject VP6;
    public GameObject VP7;
    public GameObject VP8;
    public GameObject VP9;
    public GameObject VP10;
    public GameObject manaRecovery;
    public UiManagerEnemy uiManagerEnemy;
    public string EnemyHealth_NAME;
    public string EnemyLV_NAME;

    protected int ratio;
    protected int ratioHealthy;
    public float CreateHPdied;
    int SoluongQuaiDied;

    [SerializeField]int itemBlood;
    [SerializeField] int itemMana;
    [SerializeField] int itemVP1;
    [SerializeField] int itemVP2;
    [SerializeField] int itemVP3;
    [SerializeField] int itemVP4;
    [SerializeField] int itemVP5;
    [SerializeField] int itemVP6;
    [SerializeField] int itemVP7;
    [SerializeField] int itemVP8;
    [SerializeField] int itemVP9;
    [SerializeField] int itemVP10;

    private void Awake()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
        uiManagerEnemy = GetComponent<UiManagerEnemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth_NAME = "enemyUpHealth" + gameObject.name;
        EnemyLV_NAME = "enemyLv" + gameObject.name;
        EnemyUpHealth = PlayerPrefs.GetFloat(EnemyHealth_NAME);
        if(PlayerPrefs.GetInt(EnemyLV_NAME) <=1)
        {
            PlayerPrefs.SetInt(EnemyLV_NAME, 1);
        }
        EnemyMaxHealth = EnemyMaxHealth + EnemyUpHealth;
        SetMaxHealth();
        SetMaxHealth();
        uiManagerEnemy.UpdateName(PlayerPrefs.GetInt(EnemyLV_NAME));
        SetTiLe();

    }
    void SetTiLe()
    {
        itemMana += itemBlood;
        itemVP2 += itemVP1;
        itemVP3 += itemVP2;
        itemVP4 += itemVP3;
        itemVP5 += itemVP4;
        itemVP6 += itemVP5;
        itemVP7 += itemVP6;
        itemVP8 += itemVP7;
        itemVP9 += itemVP8;
        itemVP10 += itemVP9;
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
            SoluongQuaiDied = PlayerPrefs.GetInt("QuaiDaTieuDiet");
            PlayerPrefs.SetInt("QuaiDaTieuDiet", SoluongQuaiDied + 1);
            DropHealingItem();
            Invoke("HoiSinhEnemy", 10);

            gameObject.SetActive(false);
        }
    }
    protected virtual void DropHealingItem()
    {
        Vector3 posHealth = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
        Vector3 posItem = new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z);
        ratioHealthy = Random.Range(1, 100);
        ratio = Random.Range(1, 100);
        if(ratioHealthy <= itemBlood)
        {
            GameObject blood = Instantiate(bloodRecovery, posHealth, transform.rotation);
            blood.name = bloodRecovery.name;
        }else if(ratioHealthy <= itemMana)
        {
            GameObject mana = Instantiate(manaRecovery, posHealth, transform.rotation);
            mana.name = manaRecovery.name;
        }
        //////////////////////////////////////
        if (ratio <= itemVP1)
        {
            GameObject vp1 = Instantiate(VP1, posItem, transform.rotation);
            vp1.name = VP1.name;
        }
        else if (ratio <= itemVP2)
        {
            GameObject vp2 = Instantiate(VP2, posItem, transform.rotation);
            vp2.name = VP2.name;
        }
        else if(ratio <= itemVP3)
        {
            GameObject vp3 = Instantiate(VP3, posItem, transform.rotation);
            vp3.name = VP3.name;
        }
        else if (ratio <= itemVP4)
        {
            GameObject vp4 = Instantiate(VP4, posItem, transform.rotation);
            vp4.name = VP4.name;
        }
        else if (ratio <= itemVP5)
        {
            GameObject vp5 = Instantiate(VP5, posItem, transform.rotation);
            vp5.name = VP5.name;
        }
        else if (ratio <= itemVP6)
        {
            GameObject vp6 = Instantiate(VP6, posItem, transform.rotation);
            vp6.name = VP6.name;
        }
        else if (ratio <= itemVP7)
        {
            GameObject vp7 = Instantiate(VP7, posItem, transform.rotation);
            vp7.name = VP7.name;
        }
        else if (ratio <= itemVP8)
        {
            GameObject vp8 = Instantiate(VP8, posItem, transform.rotation);
            vp8.name = VP8.name;
        }
        else if (ratio <= itemVP9)
        {
            GameObject vp9 = Instantiate(VP9, posItem, transform.rotation);
            vp9.name = VP9.name;
        }
        else if (ratio <= itemVP10)
        {
            GameObject vp10 = Instantiate(VP10, posItem, transform.rotation);
            vp10.name = VP10.name;
        }
    }
    
    protected virtual void HoiSinhEnemy()
    {
        gameObject.SetActive(true);
        EnemyUpHealth += EnemyMaxHealth * CreateHPdied;
        PlayerPrefs.SetFloat(EnemyHealth_NAME, EnemyUpHealth);
        PlayerPrefs.SetInt(EnemyLV_NAME, PlayerPrefs.GetInt(EnemyLV_NAME) + 1);
        uiManagerEnemy.UpdateName(PlayerPrefs.GetInt(EnemyLV_NAME));
        
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
