using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public int damageToGive;
    public int damagePlayer = 10;
    public void Start()
    {
        
    }
    public void Update()
    {
        SetDamage();
    }
    private void SetDamage()
    {
        damageToGive = damagePlayer;

    }
    public void UpDamage(int upDamege)
    {
        damagePlayer += upDamege;
        PlayerPrefs.SetInt("playerAttack", damagePlayer);

    }
}
