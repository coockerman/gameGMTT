using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttackPercen : UpChiSo
{
    [SerializeField] PlayerAttackManager acttackManager;

    
    protected override void UpChiSoCoBan(int TangChiSo)
    {
        acttackManager.UpPhanTramDame((float)TangChiSo);
    }

    protected override void GetCountIndex()
    {
        textCount.text = "" + acttackManager.TangPhanTramDame + "%";
    }
}
