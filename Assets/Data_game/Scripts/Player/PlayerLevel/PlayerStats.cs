using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;

    public int currentExp;

    protected int currentExpRedundant;

    public int[] toHpUp;

    public int[] toAttackUp;

    public int[] toLevelUp;

    public float[] toSpeedManaUp;

    private PlayerHearthManager playerHearth;
    private PlayerAttackManager playerAttack;
    private PlayerManaManager playerMana;
    private void Awake()
    {
        playerHearth = GetComponent<PlayerHearthManager>();
        playerAttack = GetComponent<PlayerAttackManager>();
        playerMana = GetComponent<PlayerManaManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Set data
        if (PlayerPrefs.GetInt("playerHearth") != 0) playerHearth.playerMaxHealth = PlayerPrefs.GetInt("playerHearth");
        if (PlayerPrefs.GetInt("playerAttack") != 0) playerAttack.damagePlayer = PlayerPrefs.GetInt("playerAttack");
        if (PlayerPrefs.GetInt("playerMana") != 0) playerMana.playerMaxMana = PlayerPrefs.GetInt("playerMana");
        if (PlayerPrefs.GetInt("playerLV") != 0) currentLevel = PlayerPrefs.GetInt("playerLV");
        if (PlayerPrefs.GetInt("playerExp") != 0) currentExp = PlayerPrefs.GetInt("playerExp");
    }



    // Update is called once per frame
    void Update()
    {
        UpLevel();
    }

    void UpLevel()
    {
        if (currentExp >= toLevelUp[currentLevel])
        {
            if (currentLevel >= toLevelUp.Length - 1) return;
            currentExpRedundant = currentExp - toLevelUp[currentLevel];
            currentLevel++;
            currentExp = currentExpRedundant;
            playerHearth.UpHp(toHpUp[currentLevel]);
            playerAttack.UpDamage(toAttackUp[currentLevel]);
            playerMana.UpSpeedCreateMana(toSpeedManaUp[currentLevel]);

            //Luu data
            PlayerPrefs.SetInt("playerHearth", playerHearth.playerMaxHealth);
            PlayerPrefs.SetInt("playerMana", playerMana.playerMaxMana);
            PlayerPrefs.SetInt("playerAttack", playerAttack.damagePlayer);
            PlayerPrefs.SetInt("playerLV", currentLevel);

        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
        PlayerPrefs.SetInt("playerExp", currentExp);
    }
}
