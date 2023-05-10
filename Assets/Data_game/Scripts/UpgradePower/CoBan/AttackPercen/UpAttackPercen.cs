using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttackPercen : UpChiSo
{
    PlayerAttackManager acttackManager;

    private void Awake()
    {
        acttackManager = PlayerAttackManager.instance;
    }
    protected override void UpChiSoCoBan(int TangChiSo)
    {
        acttackManager.UpPhanTramDame((float)TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + acttackManager.TangPhanTramDame + "%";
    }
}
