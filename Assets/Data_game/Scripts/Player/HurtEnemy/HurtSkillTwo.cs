using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkillTwo : HurtEnemy
{
    public override void Update()
    {
        base.Update();
        damageToGive = SetDame(2f);
    }
}
