﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillHoiHp : SkillHoiPhuc
{
    [SerializeField] PlayerHearthManager playerHearth;
    protected override void Start()
    {
        SAVE_LV = "lvHealth";
        base.Start();

    }
    public override void OnHoiPhuc()
    {
        base.OnHoiPhuc();
        hoiPhuc = playerHearth.playerMaxHealth * dataLVHoiPhuc[lvHoiPhuc] * 0.01f;
        playerHearth.HoiHp((int)hoiPhuc);
    }
    protected override void SetChuThich()
    {
        ChuThichHoiPhuc.text = "Hồi lại " + dataLVHoiPhuc[lvHoiPhuc] + "% HP tối đa ";
        base.SetChuThich();
    }


}
