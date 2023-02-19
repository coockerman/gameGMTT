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
    // Start is called before the first frame update
    void Start()
    {
        playerHearth = GetComponent<PlayerHearthManager>();
        playerAttack = GetComponent<PlayerAttackManager>();
        playerMana = GetComponent<PlayerManaManager>();
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
            if (currentLevel >= toLevelUp.Length-1) return;
            currentExpRedundant = currentExp - toLevelUp[currentLevel];
            currentLevel++;
            currentExp = currentExpRedundant;
            playerHearth.UpHp(toHpUp[currentLevel]);
            playerAttack.UpDamage(toAttackUp[currentLevel]);
            playerMana.UpSpeedCreateMana(toSpeedManaUp[currentLevel]);
        }
    }
    
    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}
