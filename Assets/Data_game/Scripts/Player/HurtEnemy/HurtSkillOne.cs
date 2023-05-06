using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkillOne : HurtEnemy
{
    [SerializeField] AudioClip Chem;

    void Update()
    {
        damageToGive = SetDame(1f);
    }
    protected override void OnShot()
    {
        audioPlayer.PlayOneShot(Chem);
    }
}
