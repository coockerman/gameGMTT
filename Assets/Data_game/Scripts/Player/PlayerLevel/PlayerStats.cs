using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LvText;
    public int currentLevel;
    public int currentExp;

    protected int currentExpRedundant;

    public int[] toHpUp;
    public int[] toAttackUp;
    public int[] toLevelUp;
    public float[] toSpeedManaUp;
    public int[] toManaUp;

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
        LoadPlayerData();
        UpLoadLvText();
    }
    void LoadPlayerData()
    {
        currentLevel = PlayerPrefs.GetInt("playerLV", currentLevel);
        currentExp = PlayerPrefs.GetInt("playerExp", currentExp);

        if (PlayerPrefs.HasKey("playerHearth"))
            playerHearth.playerMaxHealth = PlayerPrefs.GetInt("playerHearth");

        if (PlayerPrefs.HasKey("playerAttack"))
            playerAttack.damagePlayer = PlayerPrefs.GetInt("playerAttack");

        if (PlayerPrefs.HasKey("playerMana"))
            playerMana.playerMaxMana = PlayerPrefs.GetInt("playerMana");
    }


    // Update is called once per frame
    void Update()
    {
        //UpLevel();
    }

    void UpLevel()
    {
        while (currentExp >= toLevelUp[currentLevel])
        {
            if (currentLevel >= toLevelUp.Length - 1)
                return;
            currentExp -= toLevelUp[currentLevel];
            currentLevel++;
            playerHearth.UpHp(toHpUp[currentLevel]);
            playerAttack.UpDamage(toAttackUp[currentLevel]);
            playerMana.UpSpeedCreateMana(toSpeedManaUp[currentLevel]);
            playerMana.UpMana(toManaUp[currentLevel]);
        }

        PlayerPrefs.SetInt("playerLV", currentLevel);
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
        PlayerPrefs.SetInt("playerExp", currentExp);
        UpLevel();
        UpLoadLvText();
    }
    public virtual void UpLoadLvText()
    {
        if(currentLevel != 0)
        LvText.text = "LV: " + currentLevel + "\n" + "Exp: " + currentExp + "/" + toLevelUp[currentLevel];
    }
}
