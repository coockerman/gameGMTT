using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkillTwo : HurtEnemy
{
    [SerializeField] AudioClip Dam;

    void Update()
    {
        damageToGive = SetDame(2f);
    }
    protected override void OnShot()
    {
        audioPlayer.PlayOneShot(Dam);
    }
}
