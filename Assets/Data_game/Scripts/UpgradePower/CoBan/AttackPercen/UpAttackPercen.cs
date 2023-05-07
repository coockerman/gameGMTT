using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttackPercen : UpChiSo
{
    PlayerAttackManager acttackManager;

    // Start is called before the first frame update
    void Awake()
    {
        acttackManager = PlayerAttackManager.instance;
    }

    protected override void UpChiSoCoBan(int TangChiSo)
    {
        acttackManager.UpPhanTramDame(TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + acttackManager.TangPhanTramDame + "%";
    }
}
