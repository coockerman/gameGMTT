using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public static PlayerAttackManager instance;

    public float damageToGive;
    public int damagePlayer;

    public float TangPhanTramDame;
    private void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        TangPhanTramDame = PlayerPrefs.GetFloat("playerPtAttack");
    }
    public void Update()
    {
        SetDamage();
    }
    void SetDamage()
    {
        if(damageToGive != ((float)damagePlayer + (float)damagePlayer*(float)(TangPhanTramDame/100)))
        damageToGive = ((float)damagePlayer + (float)damagePlayer * (float)(TangPhanTramDame / 100));

    }
    public void UpDamage(int upDamege)
    {
        damagePlayer += upDamege;
        PlayerPrefs.SetInt("playerAttack", damagePlayer);
    }
    public void UpPhanTramDame(float ptDame)
    {
        TangPhanTramDame += ptDame;
        PlayerPrefs.SetFloat("playerPtAttack", TangPhanTramDame);
    }
}
