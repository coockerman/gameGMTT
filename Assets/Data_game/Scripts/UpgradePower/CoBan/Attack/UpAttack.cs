using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttack : UpChiSo
{
    [SerializeField] PlayerAttackManager acttackManager;

    
    protected override void UpChiSoCoBan(int TangChiSo)
    {
        acttackManager.UpDamage(TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + acttackManager.damagePlayer;
    }
}
