using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpMana : UpChiSo
{
    [SerializeField] PlayerManaManager manaManager;

    
    protected override void UpChiSoCoBan(int TangChiSo)
    {
        manaManager.UpMana(TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + manaManager.playerMaxMana;
    }
}
