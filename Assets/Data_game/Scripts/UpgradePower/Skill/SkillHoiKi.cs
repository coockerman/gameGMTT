using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHoiKi : SkillHoiPhuc
{
    [SerializeField] PlayerManaManager playerMana;

    public override void OnHoiPhuc()
    {
        base.OnHoiPhuc();
        hoiPhuc = playerMana.playerMaxMana * dataLVHoiPhuc[lvHoiPhuc] * 0.01f;
        playerMana.HoiMana((int)hoiPhuc);
    }
    protected override void SetTimeHoiPhuc()
    {
        SAVE_LV = "lvMana";
        base.SetTimeHoiPhuc();
    }
    protected override void SetChuThich()
    {
        ChuThichHoiPhuc.text = "Hồi lại " + dataLVHoiPhuc[lvHoiPhuc] + "% KI tối đa ";
        base.SetChuThich();
    }
}
