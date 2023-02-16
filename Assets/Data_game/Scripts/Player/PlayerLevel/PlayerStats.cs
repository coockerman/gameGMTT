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

    private PlayerHearthManager playerHearth;
    public PlayerAttackManager playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        playerHearth = FindObjectOfType<PlayerHearthManager>();
        playerAttack = FindObjectOfType<PlayerAttackManager>();
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
        }
    }
    
    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}
