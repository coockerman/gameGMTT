using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHP : UpChiSo
{
    [SerializeField] PlayerHearthManager hearthManager;

    // Start is called before the first frame update
    void Awake()
    {
        //hearthManager = PlayerHearthManager.instance;
    }

    protected override void UpChiSoCoBan(int TangChiSo)
    {
        hearthManager.UpHp(TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + hearthManager.playerMaxHealth;
    }
}
