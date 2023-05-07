using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpMana : UpChiSo
{
    PlayerManaManager manaManager;

    // Start is called before the first frame update
    void Awake()
    {
        manaManager = PlayerManaManager.instance;
    }

    protected override void UpChiSoCoBan(int TangChiSo)
    {
        manaManager.UpMana(TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + manaManager.playerMaxMana;
    }
}
