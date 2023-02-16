using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkillOne : HurtEnemy
{
    public override void Update()
    {
        base.Update();
        damageToGive = SetDame(1f);
    }
}
